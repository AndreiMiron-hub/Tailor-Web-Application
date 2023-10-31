import PropTypes from 'prop-types';
import { NavLink as RouterLink, useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { FormattedMessage, useIntl } from 'react-intl';
import { useDispatch, useSelector } from 'react-redux';

// @mui
import { Box, Card, Link, Typography, Stack, Popover, MenuItem } from '@mui/material';
import { styled } from '@mui/material/styles';

// utils
import { fCurrency } from '../../../../utils/formatNumber';
// components
import Label from '../../../../components/label';
import { ColorPreview } from '../../../../components/color-utils';
import Iconify from '../../../../components/iconify';
import { AdminControls } from '../../../../components';
import {
  BasicModal,
  ProductModal
} from '../../../../components/modals';
import { deleteProduct } from '../../../../config/redux/slices/ProductSlice';

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
  const [open, setOpen] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const dispatch = useDispatch();

  const [showConfirmation, setShowConfirmation] = useState(false);
  const intl = useIntl();

  const handleClick = () => {
      onSelected(product);
      navigate(`/product/${product.id}`);
    };

    const onProductEdit = () => {
      setShowEditModal(true);
    };

    const handleOnClose = () => {
      setShowEditModal(false);
    };
  
    const onConfirmDeleteProduct = () => {
      dispatch(deleteProduct(product.id));
      setShowConfirmation(false);
    };

    const handleRemove = () => {
      setShowConfirmation(true);
    };

  return (
      <Card 
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

          <AdminControls
            mb='2rem'
            controlsList={[
              { name: 'edit', onClick: onProductEdit, iconColor: 'white' },
              { name: 'delete', onClick: handleRemove, iconColor: 'white' },
            ]}
          />
        </Stack>
        {showConfirmation && (
          <BasicModal
            isError
            open={showConfirmation}
            onClose={() => setShowConfirmation(false)}
            title={<FormattedMessage id = {"lbl.product-delete-confirmation"}/>}
            onSubmit={onConfirmDeleteProduct}
            save= {intl.formatMessage({ id: "lbl.button.ok" })}
            close = {intl.formatMessage({id: "lbl.button.cancel"})}
          />
        )}

        {showModal && <ProductModal open={showEditModal} onClose={handleOnClose}/>}
        {showEditModal && <ProductModal open={showEditModal} onClose={handleOnClose}/>}
      </Card>

);
}
