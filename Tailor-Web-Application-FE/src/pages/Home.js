import React from 'react';
import { Helmet } from 'react-helmet-async';

import { Box, Typography} from '@mui/material';
import { FormattedMessage } from 'react-intl';

import { DescriptionSection,
  OfferedServices,
  StafFSection,
  GoogleMap,
  ContactUsSection,
  NewsSection,
} from '../sections/homePage';
import { ScrollToTopButton } from '../components';
import img from '../assets/Carousel_1.jpg';

export default function Home() {

  return (
    <>
    <Helmet>
      <title> Home | Tailor Web App </title>
    </Helmet>

    <Box sx ={{
        display: 'flex', 
        justifyContent: 'center', 
        flexDirection: 'column', 
        alignItems: 'center',
        }} >

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

          <FormattedMessage id="lbl.home.header"/>
          
        </Typography>

        <DescriptionSection/>
        <OfferedServices/>
        <StafFSection/>
        <GoogleMap/>
        <ContactUsSection/>
        <NewsSection/>
        <ScrollToTopButton/>

    </Box> 
    </>
    );
  }