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

export default function ShopProductCard({ product, onSelected }) {
  const navigate = useNavigate();

  const handleClick = () => {
      onSelected(product);
      navigate(`/product/${product.id}`);
    };

  return (
      <Card 
            onClick={handleClick}
            sx = {{backgroundColor: '#454456', border: '2px dotted #DEB18A', cursor: 'pointer', userSelect: 'none'
          }}>
        <Box sx={{ pt: '100%', position: 'relative' }}>
          <StyledProductImg alt={product.name} src={product.image} />
        </Box>

        <Stack spacing={0.5} sx={{ p: 3 }}>
            <Typography variant="subtitle2" noWrap fontSize="20px" fontWeight="bold" color="white">
              {product.name}
            </Typography>
          <Stack direction="row" alignItems="center" justifyContent="space-between">
            <Typography color= "white" fontSize="15px">Culoare {product.color}</Typography>
            <Typography display= "flex" fontSize="20px" flexDirection= "row" variant="subtitle1" color= "white">
              &nbsp;
              {fCurrency(product.price)}
              <Typography fontSize="20px">LEI</Typography>
            </Typography>
          </Stack>
        </Stack>
      </Card>
  );
}
