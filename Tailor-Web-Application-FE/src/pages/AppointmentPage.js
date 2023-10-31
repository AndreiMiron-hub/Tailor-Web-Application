import React from 'react';
import { Helmet } from 'react-helmet-async';
import { Box, Typography } from '@mui/material';

import headerImage from '../assets/ContactImage.jpg';
import  {GoogleMap} from '../sections/homePage';
import { InformationSection, ContactUsFormSection } from '../sections/contactPage';
import { AppointmentSection } from '../sections/appointmentPage';
import { ScrollToTopButton } from '../components';

export default function AppointmentPage() {

    return (
      <>
        <Helmet>
          <title> Appointment | Tailor Website </title>
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
        Programare
      </Typography>

      <GoogleMap/>
      <InformationSection/>
      <AppointmentSection/>
      <ScrollToTopButton/>
      </>
      );
    }