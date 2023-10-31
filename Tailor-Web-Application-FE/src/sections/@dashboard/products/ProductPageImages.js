/* eslint-disable arrow-body-style */
import PropTypes from 'prop-types';
import { NavLink as RouterLink, useNavigate } from 'react-router-dom';

// @mui
import { Box, Card, Link, Typography, Stack } from '@mui/material';
import { styled } from '@mui/material/styles';
// utils
import { fCurrency } from '../../../utils/formatNumber';
// components
import Label from '../../../components/label';
import { ColorPreview } from '../../../components/color-utils';

// ----------------------------------------------------------------------

const StyledProductImg = styled('img')({
  top: 0,
  width: '100%',
  height: '100%',
  objectFit: 'cover',
  position: 'absolute',
});

// ----------------------------------------------------------------------

const ProductPageImages = ({ images }) => {
  return (
      <Box sx = {{
        backgroundColor: '#DEB18A',
        border: '2px dotted #454456',
        mr: 2

      }}>
        <img src = {images} alt = "" style = {{
            width:'100px'
        }}/>
      </Box>
    );
}

export default ProductPageImages;
