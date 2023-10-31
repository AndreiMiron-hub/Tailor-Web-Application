import React from 'react';
import { useIntl } from 'react-intl';

import { FormLabel, FormControl, RadioGroup, FormControlLabel, Radio } from '@mui/material';

const NewsStatus = ({ values, setValues }) => {
  const intl = useIntl();

  const handleChange = (event) => {
    setValues({ ...values, newsStatus: parseInt(event.target.value, 10) });
  };

  return (
<FormControl sx={{ color: 'white' }}>
  <FormLabel id="newsStatus">{intl.formatMessage({ id: 'lbl.news-status' })}</FormLabel>
  <RadioGroup
    row
    aria-labelledby="newsStatus"
    name="newsStatus"
    value={values.newsStatus}
    onChange={handleChange}
    sx={{ color: 'white' }}
  >
    <FormControlLabel
      value={2}
      control={<Radio sx={{ color: 'white' }} />}
      label={intl.formatMessage({ id: 'lbl.news-status-post' })}
      sx={{ color: 'white' }}
    />

    <FormControlLabel
      value={1}
      control={<Radio sx={{ color: 'white' }} />}
      label={intl.formatMessage({ id: 'lbl.news-status-draft' })}
      sx={{ color: 'white' }}
    />
    <FormControlLabel
      value={3}
      control={<Radio sx={{ color: 'white' }} />}
      label={intl.formatMessage({ id: 'lbl.news-status-scheduled' })}
      sx={{ color: 'white' }}
    />
  </RadioGroup>
</FormControl>
  );
};

export default NewsStatus;
