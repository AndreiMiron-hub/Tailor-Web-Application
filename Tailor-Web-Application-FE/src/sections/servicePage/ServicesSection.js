/* eslint-disable react/jsx-key */
/* eslint-disable arrow-body-style */
/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { Box, Grid } from '@mui/material';

import SuitsServiceImage from '../../assets/SuitsServiceImage.jpg'
import { HorizontalServiceCard } from '../../components/service-cards';

import {
    setServiceError,
    setServiceStatus,
    setSelectedService,
    getServices,
  } from '../../config/redux/slices/ServiceSlice';

const ServicesSection = () => {

    const dispatch = useDispatch();
    const [error, setError] = useState(null);
  
    const {
        loading,
        services,
        serviceError,
        service_status,
    } = useSelector((state) => state.services)
    
    useEffect(() => {
      if(!services && !(service_status === 'failed')) 
      {
        dispatch(getServices());
      }
      if(service_status === 'failed' && serviceError) {
        setError(true);
      }
      if(services && serviceError && service_status === 'failed')
      {
        dispatch(setServiceError(null));
        dispatch(setServiceStatus(null));
      }
    }, [services, service_status, dispatch, serviceError]);

    return (
        <Box sx = {{
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
            px: '50px',
            height: '670px',
            mx: '20px',
        }}> 
        <Grid container spacing={2}>

        {!loading &&
            services &&
            services.slice(0, 4).map((service, index) => {
                return  <Grid item xs={6}>
                            <HorizontalServiceCard key={index + service.id} service={service}/>
                        </Grid>
            })}
        </Grid>

        </Box>
    )
};

export default ServicesSection;