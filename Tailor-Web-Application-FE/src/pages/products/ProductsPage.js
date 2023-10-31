/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { Helmet } from 'react-helmet-async';
import { FormattedMessage } from 'react-intl';

// @mui
import { Container, Stack, Typography, Box } from '@mui/material';
// components
import { ProductSort, ProductList, ProductCartWidget, ProductFilterSidebar } from '../../sections/@dashboard/products';

import img from '../../assets/Carousel_1.jpg';

import {
  setProductError,
  setProductStatus,
  setSelectedProduct,
  getProducts
} from '../../config/redux/slices/ProductSlice';
// ----------------------------------------------------------------------


export default function ProductsPage() {
  const [openFilter, setOpenFilter] = useState(false);
  const dispatch = useDispatch();
  const [error, setError] = useState(null);

  const handleOpenFilter = () => {
    setOpenFilter(true);
  };

  const handleCloseFilter = () => {
    setOpenFilter(false);
  };

  const {
      loading,
      products,
      productError,
      product_status,
    } = useSelector((state) => state.products)
  
  useEffect(() => {
    if(!products && !(product_status === 'failed')) 
    {
      dispatch(getProducts());
    }
    if(product_status === 'failed' && productError) {
      setError(true);
    }
    if(products && productError && product_status === 'failed')
    {
      dispatch(setProductError(null));
      dispatch(setProductStatus(null));
    }
  }, [products, product_status, dispatch, productError]);

  const onSelectedProduct = (products) => {
    dispatch(setSelectedProduct(products));
  };

  return (
    <>
      <Helmet>
        <title> Products | Tailor Web App </title>
      </Helmet>

      <Box sx={{ 
        display: 'flex',
        overflow: 'hidden',
        position: 'relative', 
        width: '100%', 
        height: '400px'
        }}>
          <img
            width='100%'
            height='100%'
            style={{ objectFit: 'cover' }}
            src={img}
            alt=""
            />
      </Box>

      <Typography
          sx={{
            position: 'absolute',
            top: '25%',
            left: '45%',
            color: 'white',
            fontWeight: 'bold',
            textShadow: '2px 2px 4px rgba(0, 0, 0, 0.5)',
            fontSize: '50px',
            zIndex: 2,
          }}>

<FormattedMessage id = "lbl.products.title"/>
          
        </Typography>

      <Container>
        <Stack direction="row" flexWrap="wrap-reverse" alignItems="center" justifyContent="flex-end" sx={{ mb: '50px' }}>
          <Stack direction="row" spacing={1} flexShrink={0} sx={{ my: 1 }}>
            <ProductFilterSidebar
              openFilter={openFilter}
              onOpenFilter={handleOpenFilter}
              onCloseFilter={handleCloseFilter}
            />
            <ProductSort />
          </Stack>
        </Stack>

        <ProductList products={products} loading = {loading}  onSelected={onSelectedProduct}/>
      </Container>
    </>
  );
}
