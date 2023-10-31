/* eslint-disable no-unneeded-ternary */
/* eslint-disable camelcase */

import React, { useState, useEffect } from 'react';
import { useIntl } from 'react-intl';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import * as Yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';

// @mui
import { Link,Box, Typography, Stack, IconButton, InputAdornment, TextField, Checkbox } from '@mui/material';
import { LoadingButton } from '@mui/lab';
// components
import Iconify from '../../../components/iconify';

import { login, doLogout, setAuthError, setAuthStatus } from '../../../config/redux/slices/AuthSlice';

import { BasicModal, ErrorDescription } from '../../../components/modals';
// ----------------------------------------------------------------------

const defaultInputValues = {
  email: '',
  password: '',
};

export default function LoginForm() {

  const dispatch = useDispatch();
  const navigate = useNavigate();
  const intl = useIntl();
  const [showPassword, setShowPassword] = useState(false);
  const [values, setValues] = useState(defaultInputValues);
  const [error, setError] = useState(null);

  const { loggedIn, authError, auth_status } = useSelector((state) => state.auth);

  const handleClick = () => {
    navigate('/dashboard', { replace: true });
  };

  useEffect(() => {
    if (auth_status === 'failed' && authError) {
      setError(true);
    }
    if (auth_status === 'success') {
      dispatch(setAuthStatus(null));
      navigate('/dashboard', { replace: true });
    }
  }, [auth_status, dispatch]);

  const validationSchema = Yup.object().shape({
    password: Yup.string().required('Password is required'),
    email: Yup.string().required('Email is required').email('Email is invalid.'),
  });

  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm({
    mode: 'all',
    reValidateMode: 'onTouched',
    resolver: yupResolver(validationSchema),
  });


  const addUser = (data) => {
    console.log(data);
    dispatch(login(data));
  };

  const handleChange = (value) => {
    setValues(value);
  };

  const handleError = () => {
    setError(false);
    dispatch(setAuthError(null));
    dispatch(setAuthStatus(null));
  };

  return (
    <>
      <Stack spacing={3} >
        <TextField sx = {{"& .MuiOutlinedInput-root": { border: "1px solid black" },
                          "& .MuiInputLabel-root": {color: "black"}, }}

                    name="email" 
                    label={intl.formatMessage({ id: 'lbl.login.user' })} 

                    autoComplete='email'
                    required
                    {...register('email')}
                    error={errors.email ? true : false}
                    helperText={errors.email?.message}
                    value={values.email}
                    onChange={(event) => {
                      handleChange({ ...values, email: event.target.value });
                      setValue('email', event.target.value);
                    }}
                    />

        <TextField
          name="password"
          label={intl.formatMessage({ id: 'lbl.login.password' })}
          type={showPassword ? 'text' : 'password'}
          sx = {{"& .MuiOutlinedInput-root": { border: "1px solid black" },
                          "& .MuiInputLabel-root": {color: "black"}, }}
          
          {...register('password')}
          autoComplete='current-password'
          required
          error={errors.password ? true : false}
          helperText={errors.password?.message}
          value={values.password}
          onChange={(event) => {
            handleChange({ ...values, password: event.target.value });
            setValue('password', event.target.value);
          }}
          
                          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                <IconButton onClick={() => setShowPassword(!showPassword)} edge="end">
                  <Iconify icon={showPassword ? 'eva:eye-fill' : 'eva:eye-off-fill'} />
                </IconButton>
              </InputAdornment>
            ),
          }}
        />
      </Stack>

      <Stack direction="row" alignItems="center" justifyContent="space-between" sx={{ my: 2 }}>
        <Box sx = {{
          display: 'flex',
          flexDirection: 'row',
          alignItems: 'center',
          justifyContent: 'center'
        }}>
          <Checkbox sx={{
                    color: '#454456',
                    '&.Mui-checked': {
                      color: '#454456',
                    }}}
                    name="remember" label="Remember me" />
          <Typography> {intl.formatMessage({ id: 'lbl.login.rememberMe' })} </Typography>
        </Box>
        
      </Stack>

      <LoadingButton sx={{
          backgroundColor: "#454456",
          color: "white",
          "&:hover": {
            backgroundColor: "Black",
          }}} 
          fullWidth
          size="large" 
          type="submit" 
          variant="contained" 
          // onClick={handleClick}
          onClick={handleSubmit(addUser)}
          >
        Login
      </LoadingButton>

      {error && (
          <BasicModal
            isError
            open={error}
            onClose={handleError}
            title={authError && <ErrorDescription error={authError} />}
            onSubmit={handleError}
            save='Ok'
            close='Cancel'
          />
        )}
    </>
  );
}
