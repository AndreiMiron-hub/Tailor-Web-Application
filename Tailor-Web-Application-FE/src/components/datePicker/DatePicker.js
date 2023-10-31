import * as React from 'react';
import dayjs from 'dayjs';
import TextField from '@mui/material/TextField';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { MobileDatePicker } from '@mui/x-date-pickers/MobileDatePicker';

const DatePicker = ({
  label,
  name,
  values,
  handleChange,
  ...props
}) => {
  const [value, setValue] = React.useState(values[name]);

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <MobileDatePicker
        {...props}
        openTo='year'
        views={['year', 'month', 'day']}
        label={label}
        showToolbar={false}
        value={dayjs(value)}
        onChange={(newValue) => {
          setValue(newValue);
          handleChange({ ...values, [name]: dayjs(newValue).format()});
        }}
        renderInput={(params) => <TextField {...params} />}
      />
    </LocalizationProvider>
  );
};

export default DatePicker;
