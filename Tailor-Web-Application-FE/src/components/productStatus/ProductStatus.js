import React from 'react';
import { useIntl } from 'react-intl';

import { FormLabel, FormControl, RadioGroup, FormControlLabel, Radio } from '@mui/material';

const ProductStatus = ({ values, setValues }) => {
  const intl = useIntl();

  const handleChange = (event) => {
    setValues({ ...values, productStatus: parseInt(event.target.value, 10) });
  };

  return (
<FormControl sx={{ color: 'white' }}>
  <FormLabel id="productStatus">{intl.formatMessage({ id: "lbl.product.status" })}</FormLabel>
  <RadioGroup
    row
    aria-labelledby="productStatus"
    name="productStatus"
    value={values.productStatus}
    onChange={handleChange}
    sx={{ color: 'white' }}
  >
    <FormControlLabel
      value={2}
      control={<Radio sx={{ color: 'white' }} />}
      label={intl.formatMessage({ id: "lbl.product-status-available" })}
      sx={{ color: 'white' }}
    />

    <FormControlLabel
      value={1}
      control={<Radio sx={{ color: 'white' }} />}
      label={intl.formatMessage({ id: "lbl.product-status-outofstock" })}
      sx={{ color: 'white' }}
    />
    <FormControlLabel
      value={3}
      control={<Radio sx={{ color: 'white' }} />}
      label={intl.formatMessage({ id: "lbl.product-status-reserved" })}
      sx={{ color: 'white' }}
    />
  </RadioGroup>
</FormControl>
  );
};

export default ProductStatus;
