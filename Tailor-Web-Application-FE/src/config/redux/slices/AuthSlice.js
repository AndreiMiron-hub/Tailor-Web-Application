/* eslint-disable prefer-const */
/* eslint-disable consistent-return */
/* eslint-disable no-unused-vars */
import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import Storage from 'store2';
import TWAException from '../../../exceptions/TWAException';
import { TwaAPI } from '../../../rest/RestClient';
import ERROR_CODES from '../../../common/ErrorCodes';
import tailorList from '../../../_mock/tailorList';

export const login = createAsyncThunk(
  'authSlice/login',
  async ({ email, password }, { dispatch, rejectWithValue }) => {
  

    try {

      const admin = {
        email: 'admin@admin.com',
        password: 'Admin123@',
      };

      const contentWriter = {
        email: 'tailor@tailor.com',
        password: 'Tailor123@',
      };

      const accFound = tailorList.find(
        (tailor) => 
        tailor.email === email && tailor.password === password
      );

      if(accFound)
      {
        const { email, role, avatarUrl, name } = accFound;
         dispatch(
          doLogin({
            email, role, profileImg : avatarUrl, name
          }),
         );
      }
      else {
        throw new TWAException(ERROR_CODES.ACCOUNT_NOT_FOUND, 'Account not found');
      }
    } catch (err) {
      return rejectWithValue(err);
    }
  },
);

const authSlice = createSlice({
  name: 'auth',
  initialState: {
    email: Storage.get('email') ?? null,
    name: Storage.get('name') ?? null,
    profileImg: Storage.get('profileImg') ?? null,
    loggedIn: Storage.get('logged_in') ?? false,
    role: Storage.get('role') ?? 'guest',
    authLoading: false,
    authError: null,

    auth_status: null,
  },
  reducers: {
    doLogin(state, action) {
      let { email, role, profileImg, name } = action.payload;

      Storage.set('email', email, true);
      Storage.set('role', role, true);
      Storage.set('profileImg', profileImg, true);
      Storage.set('name', name, true);

      let loggedIn = !!role;
      Storage.set('logged_in', loggedIn, true);

      return {
        ...state,
        loggedIn,
        role,
        email,
        profileImg,
        name,
      };
    },
    doLogout(state) {
      Storage.remove('email');
      Storage.remove('role');
      Storage.remove('logged_in');
      Storage.remove('name');
      Storage.remove('profileImg')

      return {
        ...state,
        loggedIn: false,
        email: null,
      };
    },
    setAuthError: (state, action) => {
      state.authError = action.payload;
    },
    setAuthStatus: (state, action) => {
      state.auth_status = action.payload;
    },
  },
  extraReducers: {
    [login.pending]: (state) => {
      state.authLoading = true;
      state.authError = null;
      state.auth_status = 'loading';
    },
    [login.fulfilled]: (state) => {
      state.authLoading = false;
      state.auth_status = 'success';
    },
    [login.rejected]: (state, action) => {
      state.authLoading = false;
      state.authError = action.payload;
      state.auth_status = 'failed';
    },
  },
});

export const { doLogin, doLogout, setAuthError, setAuthStatus } = authSlice.actions;

export default authSlice.reducer;
