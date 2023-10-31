import React, { useState } from 'react';
import { Helmet } from 'react-helmet-async';
import { Box, Typography } from '@mui/material';

import headerImage from '../assets/ContactImage.jpg';
import  {GoogleMap} from '../sections/homePage';
import { InformationSection, ContactUsFormSection } from '../sections/contactPage';
import image1 from '../assets/Galery1.jpg';
import image2 from '../assets/Galery2.jpg';
import image3 from '../assets/Galery3.jpg';
import image4 from '../assets/Galery4.jpg';
import image5 from '../assets/Galery5.jpg';
import image6 from '../assets/Galery6.jpg';
import image7 from '../assets/Galery7.jpg';
import image8 from '../assets/Galery8.jpg';


export default function Galery() {
    const images = [image1, image2, image3, image4, image5, image6, image7, image8];

    return (
      <>
        <Helmet>
          <title> Galery | Tailor Website </title>
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
        Contact
      </Typography>

        <Box sx = {{
            my: '10px',
        }}>
            {images.map((image, index) => (
                <img key={index} src={image} alt="" />
                ))}
        </Box>
      </>
      );
    }