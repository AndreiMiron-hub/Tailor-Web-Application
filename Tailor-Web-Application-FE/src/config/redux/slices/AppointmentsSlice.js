import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { TwaAPI } from '../../../rest/RestClient';

export const getAppointments = createAsyncThunk(
    'appointments/getAppointments',
    async (args, { rejectWithValue }) => {
        try {
            return await TwaAPI.GET('/Appointment');
        } catch (err) {
            return rejectWithValue(err);
        }
    },
);

export const newAppointment = createAsyncThunk(
    'appointments/newAppointment',
    async (appointmentRequest, { rejectWithValue }) => {
      try {
        return await TwaAPI.POST(`/Appointment/`, appointmentRequest);
      } catch (err) {
        return rejectWithValue(err);
      }
    },
  );

export const deleteAppointment = createAsyncThunk(
        'appointments/deleteAppointment',
        async (id, { rejectWithValue }) => {
            try {
            return await TwaAPI.DELETE(`/Appointment/${id}`);
            } catch (err) {
            return rejectWithValue(err);
            }
        },
    );

export const updateAppointment = createAsyncThunk(
        'appointments/updateAppointment',
        async (appointmentRequest, { rejectWithValue }) => {
            try {
            return await TwaAPI.PUT(`/Appointment/${appointmentRequest.id}`, appointmentRequest);
            } catch (err) {
            return rejectWithValue(err);
            }
        },
    );

const appointmentsSlice = createSlice({
    name: 'appointments',
    initialState: {
        loading: false,
        appointmentError: null,

        appointments: null,

        selectedAppointment: null,

        appointments_status: null,
        new_appointments_status: null,
        delete_appointment_status: null,
        update_appointment_status: null,
    },

    reducers: {
        setAppointmentError: (state, action) => {
            state.appointmentError = action.payload;
        },
        setAppointmentStatus: (state, action) =>{
            state.appointments_status = action.payload;
        },
        setSelectedAppointment: (state, action) => {
            state.selectedAppointment = action.payload;
        },
        setNewAppointmentStatus: (state, action) => {
            state.new_appointments_status = action.payload;
        },
        setDeleteAppointmentStatus: (state, action) => {
        state.delete_appointment_status = action.payload;
        },
        setUpdateAppointmentStatus: (state, action) => {
        state.update_appointment_status = action.payload;
        },
    },

    extraReducers: {
        [getAppointments.pending]: (state) => {
            state.appointments_status = 'loading';
            state.loading = true;
            state.appointmentError = null;
        },
        [getAppointments.fulfilled]: (state, action) => {
            state.loading = false;
            state.appointments_status = 'succes';
            state.appointments = action.payload;
        },
        [getAppointments.rejected]: (state, action) => {
            state.loading = false;
            state.appointmentError = action.payload;
            state.appointments_status = 'failed';
        },

        [newAppointment.pending]: (state) => {
            state.loading = true;
            state.appointmentError = null;
            state.new_appointments_status = 'loading';
          },
          [newAppointment.fulfilled]: (state) => {
            state.loading = false;
            state.new_appointments_status = 'success';
          },
          [newAppointment.rejected]: (state, action) => {
            state.loading = false;
            state.appointmentError = action.payload;
            state.new_appointments_status = 'failed';
          },

          [deleteAppointment.pending]: (state) => {
            state.loading = true;
            state.appointmentError = null;
            state.delete_appointment_status = 'loading';
          },
          [deleteAppointment.fulfilled]: (state) => {
            state.loading = false;
            state.delete_appointment_status = 'success';
          },
          [deleteAppointment.rejected]: (state, action) => {
            state.loading = false;
            state.appointmentError = action.payload;
            state.delete_appointment_status = 'failed';
          },
      
          [updateAppointment.pending]: (state) => {
            state.loading = true;
            state.appointmentError = null;
            state.update_appointment_status = 'loading';
          },
          [updateAppointment.fulfilled]: (state) => {
            state.loading = false;
            state.update_appointment_status = 'success';
          },
          [updateAppointment.rejected]: (state, action) => {
            state.loading = false;
            state.appointmentError = action.payload;
            state.update_appointment_status = 'failed';
          },
    },
});

export const{
    setNewAppointmentStatus,
    setAppointmentError,
    setAppointmentStatus,
    setSelectedAppointment,
    setDeleteAppointmentStatus,
    setUpdateAppointmentStatus,
} = appointmentsSlice.actions;

export default appointmentsSlice.reducer;