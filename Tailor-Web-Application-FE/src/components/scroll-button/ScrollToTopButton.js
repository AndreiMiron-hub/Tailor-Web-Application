import React from 'react';
import { IconButton, Box, useScrollTrigger, Zoom } from '@mui/material';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';

const ScrollToTop = () => {
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 100,
  });

  const handleClick = () => {
    window.scrollTo({
      top: 0,
      behavior: 'smooth',
    });
  };

  return (
    <Zoom in={trigger}>
      <Box
        onClick={handleClick}
        role="presentation"
        sx={{
          position: 'fixed',
          bottom: '2rem',
          right: '2rem',
          zIndex: 9999,
        }}
      >
        <IconButton
          size = "large"
          aria-label="Scroll to top"
          sx={{
            backgroundColor: '#3A3949',
            color: 'white',
            '&:hover': {
              backgroundColor: '#DEB18A',
            },
          }}
        >
          <KeyboardArrowUpIcon />
        </IconButton>
      </Box>
    </Zoom>
  );
};

export default ScrollToTop;
