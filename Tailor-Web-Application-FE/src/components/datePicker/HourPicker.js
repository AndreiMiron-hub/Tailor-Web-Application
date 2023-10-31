import * as React from 'react';
import TextField from '@mui/material/TextField';
import { DesktopTimePicker } from '@mui/x-date-pickers/DesktopTimePicker';
import { LocalizationProvider, AdapterDayjs } from '@mui/x-date-pickers';
import AdapterDateFns from '@mui/lab/AdapterDateFns';

const HourPicker = ({ label, name, values, handleChange, ...props }) => {
  const [value, setValue] = React.useState(values[name]);

  return (
    <LocalizationProvider dateAdapter={AdapterDateFns}>
      <DesktopTimePicker
        {...props}
        label={label}
        value={value}
        onChange={(newValue) => {
          setValue(newValue);
          handleChange({ ...values, [name]: newValue });
        }}
        renderInput={(params) => <TextField {...params} />}
      />
    </LocalizationProvider>
  );
};

export default HourPicker;