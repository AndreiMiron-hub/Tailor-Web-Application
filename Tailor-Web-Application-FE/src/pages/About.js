import React from 'react';
import { Helmet } from 'react-helmet-async';
import { Box , Typography} from '@mui/material';
import { FormattedMessage } from 'react-intl';

import img from '../assets/Carousel_1.jpg';
import {AboutUsSection, VideoSection} from '../sections/aboutPage';
import { StafFSection } from '../sections/homePage';
import { ScrollToTopButton } from '../components';

export default function About() {
  return (
    <>
      <Helmet>
        <title> About | Tailor Website </title>
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
        <FormattedMessage id="lbl.about.header"/>
      </Typography>

      <AboutUsSection/>
      <VideoSection/>
      <StafFSection/>
      <ScrollToTopButton/>
    </>
  );
}