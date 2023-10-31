import React, { useState, useMemo } from 'react';
import { useIntl } from 'react-intl';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';

import { Box, TextField } from '@mui/material';

import BasicModal from './BasicModal';
import { UploadImage } from '../uploadImage';

const AdminUserModal = ({ open, onClose, content = null, addNewUser }) => {
  const intl = useIntl();
  const [isImageSelected, setIsImageSelected] = useState(content ? true : null);

  const roles = [
    { id: 1, name: 'Staff' },
    { id: 2, name: 'Admin' },
  ];

  const defaultInputValues = {
    id: content ? content.id : '',
    email: content ? content.description : '',
    photoURL: content ? content.text : [],
    firstName: content ? content.firstName: '',
    lastName: content ? content.lastName: '',
    password: content ? content.password: '',
  };

  const [values, setValues] = useState(defaultInputValues);

  const validationSchema = Yup.object().shape({
    firstName: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.title-required' })} ${intl.formatMessage({
        id: 'lbl.is-required',
      })}`,
    ),
    lastName: Yup.string().required(
        `${intl.formatMessage({ id: 'lbl.title-required' })} ${intl.formatMessage({
          id: 'lbl.is-required',
        })}`,
      ),
      password: Yup.string().required(
        `${intl.formatMessage({ id: 'lbl.title-required' })} ${intl.formatMessage({
          id: 'lbl.is-required',
        })}`,
      ),
    email: Yup.string().required('Camp necesar de completat.').email('Email invalid.'),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    mode: 'onTouched',
    reValidateMode: 'onTouched',
    defaultValues: defaultInputValues,
    resolver: yupResolver(validationSchema),
  });

  const addUser = () => {
    addNewUser(values);
  };

  const handleChange = (value) => {
    setValues(value);
  };

  const addArticle = () => {
    if (!isImageSelected) {
      setIsImageSelected(false);
      return;
    }
    
    setIsImageSelected(null);
  };

  const getContent = () => (
    <Box
  sx={{
    display: 'flex',
    alignItems: ['center', 'initial', 'initial'],
    flexDirection: 'column',
    '.MuiFormControl-root': {
      mb: '20px',
      color: 'white',
    },
  }}
>
    
<TextField
        placeholder={content.firstName}
        name="firstName"
        label={"Prenume ..."}
        required
        {...register('firstName')}
        error={!!errors.firstName}
        helperText={errors.firstName?.message}
        value={values.firstName}
        onChange={(event) => handleChange({ ...values, firstName: event.target.value })}
        InputProps={{
        style: { color: 'white'},
        }}
    />

<TextField
        placeholder={content.lastName}
        name="lastName"
        label= {"Nume ..."}
        required
        {...register('lastName')}
        error={!!errors.lastName}
        helperText={errors.lastName?.message}
        value={values.lastName}
        onChange={(event) => handleChange({ ...values, lastName: event.target.value })}
        InputProps={{
        style: { color: 'white'},
        }}
    />

    <TextField
        placeholder={'email'}
        name="email"
        label={"Email ..."}
        required
        {...register('email')}
        error={!!errors.email}
        helperText={errors.email?.message}
        value={values.email}
        onChange={(event) => handleChange({ ...values, email: event.target.value })}
        InputProps={{
        style: { color: 'white'},
        }}
    />

    <TextField
        placeholder={content.password}
        name="password"
        label={"Parola ..."}
        required
        {...register('password')}
        error={!!errors.password}
        helperText={errors.password?.message}
        value={values.password}
        onChange={(event) => handleChange({ ...values, password: event.target.value })}
        InputProps={{
        style: { color: 'white'},
        }}
    />

  <UploadImage
    name="content"
    values={content}
    setValues={setValues}
    isSelected={isImageSelected}
    setIsSelected={setIsImageSelected}
    errors={errors}
  />
</Box>
  );

  return (
    <BasicModal
      open={open}
      onClose={onClose}
      title={intl.formatMessage({ id: 'lbl.add-news' })}
      content={getContent()}
      onSubmit={handleSubmit(addArticle)}
      save={content ? 'btn.save' : 'btn.add'}
      width='50rem'
      typographyProps={{ textAlign: 'center' }}
    />
  );
};

export default AdminUserModal;
