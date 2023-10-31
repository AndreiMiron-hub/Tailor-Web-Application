/* eslint-disable react/jsx-boolean-value */
import React, { useState, useMemo } from 'react';
import { useIntl } from 'react-intl';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';

import { Box, TextField } from '@mui/material';

import BasicModal from './BasicModal';
import { UploadImage } from '../uploadImage';

const UserModal = ({ open, onClose, content = null, editExistingUser }) => {
  const intl = useIntl();
  const [isImageSelected, setIsImageSelected] = useState(content ? true : null);

  const defaultInputValues = {
    id: content ? content.id : '',
    displayName: content ? content.title : '',
    email: content ? content.description : '',
    photoURL: content ? content.text : [],
  };

  const [values, setValues] = useState(defaultInputValues);

  const validationSchema = Yup.object().shape({
    displayName: Yup.string().required(
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

  const editUser = () => {
    editExistingUser(values);
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
        placeholder={content.email}
        name="email"
        label={content.email}
        required
        {...register('email')}
        error={!!errors.email}
        helperText={errors.email?.message}
        value={values.email}
        onChange={(event) => handleChange({ ...values, color: event.target.value })}
        InputProps={{
        style: { color: 'white'},
        }}
    />

    <TextField
        placeholder={content.displayName}
        name="displayName"
        label={content.displayName}
        required
        {...register('displayName')}
        error={!!errors.displayName}
        helperText={errors.displayName?.message}
        value={values.displayName}
        onChange={(event) => handleChange({ ...values, color: event.target.value })}
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
    disableValidations={true}
  />
</Box>
  );

  return (
    <BasicModal
      open={open}
      onClose={onClose}
      title={intl.formatMessage({ id: 'lbl.add-news' })}
      content={getContent()}
      onSubmit={onClose}
      save={content ? 'btn.save' : 'btn.add'}
      width='50rem'
      typographyProps={{ textAlign: 'center' }}
    />
  );
};

export default UserModal;
