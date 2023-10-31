/* eslint-disable arrow-body-style */
/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Box, Typography } from '@mui/material';
import { FormattedMessage } from 'react-intl';


import { ServiceCard }  from '../../components/service-cards';
import shape1 from "../../assets/shape-1.png";
import SuitsServiceImage from '../../assets/SuitsServiceImage.jpg';

import {
    setServiceError,
    setServiceStatus,
    setSelectedService,
    getServices,
  } from '../../config/redux/slices/ServiceSlice';

const servicesImage = [
    {
        image: SuitsServiceImage
    },
    {
        image: SuitsServiceImage
    },
    {
        image: SuitsServiceImage
    },
  ];

const OfferedServices = () => {
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
            width : '100%',
            height: '650px',
            bgcolor: '#FBF7F4',
            py: '30px',
        }}>  
          <img src = {shape1} alt = "" width = "60px"/>
        <Typography sx =  {{fontSize: '35px'}}> <FormattedMessage id="lbl.services.home"/> </Typography>
        <Box sx  ={{
            display:'flex',
            alignItems: 'center',
            justifyContent: 'center',
            flexDirection: 'row',
        }}>
            {!loading &&
            services &&
            services.slice(0, 3).map((service, index) => {
                const { image } = servicesImage[index];
                console.log(servicesImage[index]);
                return <ServiceCard key={index + service.id} service={service} imageName={ image }/>
            })}
        </Box>


        </Box>
    );
};

export default OfferedServices;