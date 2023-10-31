/* eslint-disable no-return-await */
/* eslint-disable consistent-return */
/* eslint-disable class-methods-use-this */
import qs from 'qs';
import Storage from 'store2';

import TWAException from "../exceptions/TWAException";
import ERROR_CODES from "../common/ErrorCodes";

const ABORT_TIMEOUT = 25000;
const ENDPOINT = 'https://localhost:7013';


class RestClient {
    constructor(apiUrl = `${ENDPOINT}/api`, { headers = {} } = {}) {
      this.mustWait = false;
      if (!apiUrl) {
        throw new Error('Missing apiUrl!');
      }
  
      this.headers = {
        Accept: 'application/json',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      };
  
      if (Storage.has('access_token')) {
        this.headers.Authorization = Storage.get('access_token');
      }
  
      Object.assign(this.headers, headers);
      this.apiUrl = apiUrl;
    }
  
    _fullRoute(url) {
      return `${this.apiUrl}${url}`;
    }
  
    async waiter() {
      return new Promise((resolve) => {
        setTimeout(resolve, 25);
      });
    }
  
    async _fetch(route, method, body, params) {
      if (!route) {
        throw new Error('Route is undefined!');
      }
  
      let fullRoute = this._fullRoute(route);
  
      const {
        isQuery = false,
        isForm = false,
        expectedResponse = 'json',
        noTimeout = false,
        abortHandle = null,
        noAuthorization = false,
        authorization = null,
      } = params;
  
      if (isQuery && body) {
        const query = qs.stringify(body);
        fullRoute = `${fullRoute}?${query}`;
        body = undefined;
      }
      const localAbortController = new AbortController();
      // client requested an abort handle
      if (abortHandle) {
        abortHandle.abort = () => localAbortController.abort();
      }
      let timeoutId;
      if (!noTimeout) {
        const triggerAbort = (abortControllerObj) => {
          abortControllerObj.signal.source = 'TIMEOUT';
          abortControllerObj.abort();
        };
        timeoutId = setTimeout(() => triggerAbort(localAbortController), ABORT_TIMEOUT);
      }
  
      if (isForm) {
        this.headers['Content-Type'] = 'application/x-www-form-urlencoded';
      } else {
        this.headers['Content-Type'] = 'application/json';
      }
  
      if (authorization) {
        this.headers.Authorization = `${authorization.type  } ${  authorization.token}`;
      }
  
      if (noAuthorization) {
        delete this.headers.Authorization;
      }
  
      if (!noAuthorization && !this.headers.Authorization && Storage.has('access_token')) {
        this.headers.Authorization = Storage.get('access_token');
      }
  
      const opts = {
        method,
        headers: this.headers,
        signal: localAbortController.signal,
      };
      if (body) {
        Object.assign(opts, {
          body: isForm ? qs.stringify(body) : JSON.stringify(body),
        });
      }
  
      console.log(`REQUEST: ${  JSON.stringify(opts)}`);
  
      try {
        // Perform fetch
        const response = await fetch(fullRoute, opts);
        const isOK = response.ok;
  
        if (isOK) {
          if (expectedResponse === 'json') {
            const responseJson = await response.json();
            if (response.headers.has('Authorization')) {
              this.headers.Authorization = response.headers.get('Authorization');
              Storage.set('access_token', response.headers.get('Authorization'));
            }
            console.log(`RESPONSE: ${  route  }\n${  JSON.stringify(responseJson)}`);
            return responseJson;
          } if (expectedResponse === 'blob') {
            const responseBlob = await response.blob();
            console.log(`RESPONSE: ${  route  }\n${  JSON.stringify(responseBlob)}`);
            return responseBlob;
          }
        } else {
          return response.json().then(
            (err) => {
              console.log(`ERROR: ${  JSON.stringify(err)}`);
              throw new TWAException(err.status, err.title, err.detail);
            },
            () => {
              console.log('NO RESPONSE ERROR');
              throw new TWAException(ERROR_CODES.API_OFFLINE, 'API OFFLINE');
            },
          );
        }
      } catch (error) {
        console.log(`FETCH ERROR ${  route  }: ${  error}`);
        if (error.name === 'AbortError' && localAbortController.signal.source === 'TIMEOUT') {
          throw new TWAException(ERROR_CODES.ABORT_ON_TIMEOUT_ERROR);
        }
        throw new TWAException(error.status, error.title, error.detail);
      } finally {
        if (timeoutId) {
          clearTimeout(timeoutId);
        }
      }
    }
  
    async GET(route, query, params = {}) {
      return await this._fetch(route, 'GET', query, { isQuery: true, ...params });
    }
  
    async POST(route, body, params = {}) {
      return await this._fetch(route, 'POST', body, params);
    }
  
    async PUT(route, body, params = {}) {
      return await this._fetch(route, 'PUT', body, params);
    }
  
    async DELETE(route, body, params = {}) {
      return await this._fetch(route, 'DELETE', body, params);
    }
  }
  
  export const TwaAPI = new RestClient();