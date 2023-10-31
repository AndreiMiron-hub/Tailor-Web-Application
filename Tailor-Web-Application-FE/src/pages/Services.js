import React from 'react';
import { Helmet } from 'react-helmet-async';
import { Box, Typography } from '@mui/material';
import { FormattedMessage } from 'react-intl';

import headerImage from '../assets/ServicesBanner.jpg';
import { ServiceMotivationSection, ServicesSection } from '../sections/servicePage';
import { ContactUsSection, PartnersSection } from '../sections/homePage';
import { ScrollToTopButton } from '../components';

export default function Services() {
  return (
    <>
    <Helmet>
      <title> Services | Tailor Website </title>
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
          src={headerImage}
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
      <FormattedMessage id="lbl.services.header"/>
    </Typography>

    <ServicesSection/>
    <ServiceMotivationSection/>
    <ContactUsSection/>
    <PartnersSection/>
    <ScrollToTopButton/>
  </>
  );
}