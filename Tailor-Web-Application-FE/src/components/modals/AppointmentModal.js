import React, { useState } from 'react';
import { useIntl } from 'react-intl';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';

import { Box, TextField } from '@mui/material';

import BasicModal from './BasicModal';
import { DatePicker } from '../datePicker';


const AppointmentModal = ({ open, onClose, content = null, onSubmit }) => {
  const intl = useIntl();

  const categories = [
    { id: 1, name: 'Costum' },
    { id: 2, name: 'Vesta' },
    { id: 3, name: 'Pantalon' },
    { id: 4, name: 'Camasa' },
    { id: 5, name: 'Batista' },
    { id: 6, name: 'Cravata' },
    { id: 7, name: 'Papion' },
  ];

  const defaultValues = {
    customerName: content ? content.customerName : '',
    customerEmail: content ? content.customerEmail : '',
    customerPhone: content ? content.customerPhone : '',
    appointmentDate: content ? content.appointmentDate : new Date(),
    notes: content ? content.notes : '',
  };

  const [values, setValues] = useState(defaultValues);

  const validationSchema = Yup.object().shape({
    customerName: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.title-required' })} ${intl.formatMessage({
        id: 'lbl.is-required',
      })}`,
    ),
    customerEmail: Yup.string().required('Camp necesar de completat.').email('Email invalid.'),
    customerPhone: Yup.string().required('Camp necesar de completat.'),
    // appointmentDate: Yup.date().required('Camp necesar de completat.'),
    // appointmentStartTime: Yup.string().required('Camp necesar de completat.'),
    notes: Yup.string(),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    mode: 'onTouched',
    reValidateMode: 'onTouched',
    defaultValues,
    resolver: yupResolver(validationSchema),
  });

  const onSubmitForm = () =>{
    console.log("values" , values);
    // onSubmit(values);
    onClose();
  }

  console.log(errors);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setValues((prevValues) => ({
      ...prevValues,
      [name]: value,
    }));
  }

  const handleChange = (value) => {
    setValues(value);
  };

  const getContent = () => (
    <Box
      sx={{
        display: 'flex',
        alignItems: 'center',
        flexDirection: 'column',
        '.MuiFormControl-root': {
          mb: '20px',
          color: 'white',
        },
      }}
    >
      <Box sx = {{ display: 'flex', flexDirection: 'row', justifyContent: 'space-between', width: '95%'}}>
      <TextField
        name="customerName"
        label="Nume client"
        required
        {...register('customerName')}
        error={!!errors.customerName}
        helperText={errors.customerName?.message}
        value={values.customerName}
        onChange={handleInputChange}
        InputProps={{
          style: { color: 'white' },
        }}
   
      />

      <TextField
        name="customerEmail"
        label="Email client"
        required
        {...register('customerEmail')}
        error={!!errors.customerEmail}
        helperText={errors.customerEmail?.message}
        value={values.customerEmail}
        onChange={handleInputChange}
        InputProps={{
          style: { color: 'white' },
        }}
      />

        <TextField
        name="customerPhone"
        label="Telefon client"
        required
        {...register('customerPhone')}
        error={!!errors.customerPhone}
        helperText={errors.customerPhone?.message}
        value={values.customerPhone}
        onChange={handleInputChange}
        InputProps={{
          style: { color: 'white' },
        }}
      />
</Box>
      <Box sx = {{ display: 'flex', flexDirection: 'row',justifyContent: 'space-between', width: '65%'}}>   

        <DatePicker
          label={"pick a date"}
          name='appointmentDate'
          values={values}
          handleChange={handleChange}
        />
      </Box>
      <Box sx = {{ display: 'flex', flexDirection: 'row', justifyContent: 'center', width: '90%'}}>
        
        <TextField
          name="notes"
          label="Note"
          {...register('notes')}
          error={!!errors.notes}
          helperText={errors.notes?.message}
          value={values.notes}
          onChange={handleInputChange}
          InputProps={{
            style: { color: 'white', width: '100%', minHeight: '100px' },
            multiline: true,
          }}
          InputLabelProps={{
            shrink: true,
          }}
          variant="outlined"
          fullWidth
        />
      </Box>
    </Box>
  );

  return (
    <BasicModal
      open={open}
      onClose={onClose}
      title={intl.formatMessage({ id: 'lbl.add-appointment' })}
      content={getContent()}
      onSubmit={handleSubmit(onSubmitForm)}
      save={content ? 'btn.save' : 'btn.add'}
      width="50rem"
      typographyProps={{ textAlign: 'center' }}
    />
  );
};

export default AppointmentModal;