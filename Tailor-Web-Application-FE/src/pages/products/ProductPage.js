/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { NavLink as RouterLink, useNavigate } from 'react-router-dom';

import { Helmet } from 'react-helmet-async';
import { FormattedMessage } from 'react-intl';

// @mui
import { Container, Stack, Typography, Box } from '@mui/material';
import img from '../../assets/Carousel_1.jpg';

import {
    setProductError,
    setProductStatus,
    setSelectedProduct,
    getProducts
  } from '../../config/redux/slices/ProductSlice';
import ProductPageImages  from '../../sections/@dashboard/products/ProductPageImages'

export default function ProductPage({ article, writter, onSelected }){
    const [openFilter, setOpenFilter] = useState(false);
    const dispatch = useDispatch();
    const [error, setError] = useState(null);
    const navigate = useNavigate();

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
        selectedProduct,
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


  const onSelectedNews = (products) => {
    dispatch(setSelectedProduct(products));
  };

      useEffect(() => {
        if (!selectedProduct) navigate('/blog');
      }, [selectedProduct]);

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
<Box sx = {{display:'flex', justifyContent:'center',width: '100%'}}>
        <Box sx = {{
                display: 'flex',
                flexDirection: 'row',
                justifyContent: 'center',
                height: '100%',
                width: '100rem',
                px: '30px',
                m: 3,
                p: 3,
            }}>
            <Box sx ={{
                display:'flex',
                justifyContent: 'center',
                alignItems:'left',
                flexDirection:'row',
                height:'500px',
                width:'30%',
            }}> 
            <ProductPageImages images = {selectedProduct.image}/>
            <img src = {selectedProduct.image} alt="" style = {{ height:'500px'}}/>
            </Box>
            <Box sx ={{
                display:'flex',
                flexDirection:'column',
                justifyContent:'center',
                alignItems:'center',
                height:'500px',
                width:'70%',

            }}> 
                <Box sx ={{
                    display:'flex',
                    flexDirection:'column',
                    backgroundColor: '#DEB18A',
                    borderRadius: '0 20px 0 20px',
                    border: '2px dotted #454456',
                    p: 3,
                    height:'500px',
                    width:'90%',
                    }}> 
                    <Typography sx = {{
                        fontWeight:'bold',
                        fontSize:'25px',
                        color: "#454456",
                        }}> {selectedProduct.name} </Typography>

                    <Typography sx = {{
                        fontSize:'22px',
                        color: "#454456",
                        }}> {selectedProduct.price} lei RON </Typography>
                    <Typography sx = {{
                        my:'20px',
                        fontSize:'22px',
                        color: "#454456",
                        }}> {selectedProduct.description} </Typography>

                    <Typography sx = {{
                        fontSize:'18px',
                        color: "#454456",
                        }}>Culoare: {selectedProduct.color} </Typography>
                    <Typography sx = {{
                        fontSize:'18px',
                        color: "#454456",
                        }}> Marimi: S M L XL </Typography>
                    <Typography sx = {{
                        fontSize:'18px',
                        color: "#454456",
                        }}> Material: {selectedProduct.material} </Typography>
                </Box>
            </Box>
        </Box>
        </Box>
    </>
)
}
