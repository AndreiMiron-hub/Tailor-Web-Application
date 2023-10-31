import { createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import { TwaAPI } from "../../../rest/RestClient";

export const getServices = createAsyncThunk(
    'services/getServices',
    async (args, { rejectWithValue }) => {
        try {
            return await TwaAPI.GET('/OfferedService');
        } catch (err) {
            return rejectWithValue(err);
        }
    },
);

export const newService = createAsyncThunk(
    'services/newService',
    async (serviceRequest, { rejectWithValue }) => {
      try {
        return await TwaAPI.POST(`/Service/`, serviceRequest);
      } catch (err) {
        return rejectWithValue(err);
      }
    },
  );

export const deleteService = createAsyncThunk(
        'services/deleteService',
        async (id, { rejectWithValue }) => {
            try {
            return await TwaAPI.DELETE(`/Service/${id}`);
            } catch (err) {
            return rejectWithValue(err);
            }
        },
    );

export const updateService = createAsyncThunk(
        'services/updateService',
        async (serviceRequest, { rejectWithValue }) => {
            try {
            return await TwaAPI.PUT(`/Service/${serviceRequest.id}`, serviceRequest);
            } catch (err) {
            return rejectWithValue(err);
            }
        },
    );

const serviceSlice = createSlice({
    name: 'services',
    initialState: {
        loading: false,
        serviceError: null,

        services: null,
        selectedService: null,

        services_status: null,
        new_services_status: null,
        delete_service_status: null,
        update_service_status: null,
    },

    reducers: {
        setServiceError: (state, action) => {
            state.serviceError = action.payload;
        },
        setServiceStatus: (state, action) =>{
            state.service_status = action.payload;
        },
        setSelectedService: (state, action) => {
            state.selectedService = action.payload;
        },
        setNewServiceStatus: (state, action) => {
            state.new_services_status = action.payload;
        },
        setDeleteServiceStatus: (state, action) => {
        state.delete_service_status = action.payload;
        },
        setUpdateServiceStatus: (state, action) => {
        state.update_service_status = action.payload;
        },
    },

    extraReducers: {
        [getServices.pending]: (state) => {
            state.service_status = 'loading';
            state.loading = true;
            state.serviceError = null;
        },
        [getServices.fulfilled]: (state, action) => {
            state.loading = false;
            state.service_status = 'succes';
            state.services = action.payload;
        },
        [getServices.rejected]: (state, action) => {
            state.loading = false;
            state.serviceError = action.payload;
            state.service_status = 'failed';
        },
        [newService.pending]: (state) => {
            state.loading = true;
            state.serviceError = null;
            state.new_services_status = 'loading';
          },
          [newService.fulfilled]: (state) => {
            state.loading = false;
            state.new_services_status = 'success';
          },
          [newService.rejected]: (state, action) => {
            state.loading = false;
            state.serviceError = action.payload;
            state.new_services_status = 'failed';
          },

          [deleteService.pending]: (state) => {
            state.loading = true;
            state.serviceError = null;
            state.delete_service_status = 'loading';
          },
          [deleteService.fulfilled]: (state) => {
            state.loading = false;
            state.delete_service_status = 'success';
          },
          [deleteService.rejected]: (state, action) => {
            state.loading = false;
            state.serviceError = action.payload;
            state.delete_service_status = 'failed';
          },
      
          [updateService.pending]: (state) => {
            state.loading = true;
            state.serviceError = null;
            state.update_service_status = 'loading';
          },
          [updateService.fulfilled]: (state) => {
            state.loading = false;
            state.update_service_status = 'success';
          },
          [updateService.rejected]: (state, action) => {
            state.loading = false;
            state.serviceError = action.payload;
            state.update_service_status = 'failed';
          },
    },
});

export const{
    setNewServiceStatus,
    setServiceError,
    setServiceStatus,
    setSelectedService,
    setDeleteServiceStatus,
    setUpdateServiceStatus,
} = serviceSlice.actions;

export default serviceSlice.reducer;