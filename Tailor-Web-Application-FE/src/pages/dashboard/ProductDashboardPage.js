/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { Helmet } from 'react-helmet-async';
import { FormattedMessage } from 'react-intl';

// @mui
import { Container, Stack, Typography, Box, Button } from '@mui/material';
// components
import { ProductSort, ProductList, ProductCartWidget, ProductFilterSidebar } from '../../sections/@dashboard/products';
import  DashboardProductList  from '../../sections/@dashboard/products/dashboardItems/dashboardProductList'
import Iconify from '../../components/iconify';
import { ProductModal } from '../../components/modals';

import {
  setProductError,
  setProductStatus,
  setSelectedProduct,
  setDeleteProductStatus,
  setUpdateProductStatus,
  setNewProductStatus,
  getProducts,
  newProduct,
} from '../../config/redux/slices/ProductSlice';
// ----------------------------------------------------------------------


export default function ProductsPage() {
  const [openFilter, setOpenFilter] = useState(false);
  const dispatch = useDispatch();
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);  

  const {
    loading,
    selectedProduct,
    products,
    productError,
    product_status,
    new_product_status,
    delete_product_status,
    update_product_status,
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

  useEffect(() => {
      if (delete_product_status === 'success') {
        dispatch(setDeleteProductStatus(null));
        dispatch(getProducts());
      }
      if (delete_product_status === 'failed' && productError) {
        setError(true);
      }
    }, [delete_product_status, productError, dispatch]);

  useEffect(() => {
    if (update_product_status === 'success') {
      dispatch(setUpdateProductStatus(null));
      dispatch(getProducts());
    }
    if (update_product_status === 'failed' && productError) {
      setError(true);
    }
  }, [update_product_status, productError, dispatch]);

  useEffect(() => {
      if (productError && new_product_status === 'failed') {
        setError(true);
      }

      if (new_product_status === 'success') {
        dispatch(getProducts());
        dispatch(setNewProductStatus(null));
      }
    }, [productError, new_product_status, dispatch]); 

  const handleOpenFilter = () => {
    setOpenFilter(true);
  };

  const handleCloseFilter = () => {
    setOpenFilter(false);
  };

  const onAddClick = () => {
    setShowModal(true);
  };

  const handleOnClose = () => {
    setShowModal(false);
  };

  const onSelectedProduct = (products) => {
    dispatch(setSelectedProduct(products));
  };

  
  const addNewProduct = (products) => {
    setShowModal(false);
    const productRequest = {
      customerName: products.customerName,
      customerEmail: products.customerEmail,
      customerPhone: products.customerPhone,
      appointmentDate: products.appointmentDate,
      appointmentStartTime: products.appointmentStartTime,
      notes: products.notes,
    };

    console.log("appointmentRequest" , productRequest);
    dispatch(newProduct(productRequest));
  };

  return (
    <>
      <Helmet>
        <title> Products | Tailor Web App </title>
      </Helmet>

      <Container>
      <Stack direction="row" alignItems="center" justifyContent="space-between" mb={5}  >
          <Typography variant="h4" gutterBottom color= "#454456">
            <FormattedMessage id="lbl.dashboard.products"/>
          </Typography>
          <Button variant="contained" startIcon={<Iconify icon="eva:plus-fill" />} onClick = {onAddClick}>
          <FormattedMessage id="lbl.dashboard.newProduct"/>
          </Button>
        </Stack>

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

        <DashboardProductList products={products} loading = {loading}  onSelected={onSelectedProduct}/>
      
        {showModal && <ProductModal open={showModal} onClose={handleOnClose}/>}
      </Container>
    </>
  );
}
