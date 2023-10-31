import { useState } from 'react';
import { FormattedMessage } from 'react-intl';
// @mui
import { alpha } from '@mui/material/styles';
import { Box, Divider, Typography, Stack, MenuItem, IconButton, Popover } from '@mui/material';
// components
import Iconify from '../../../components/iconify';
// ----------------------------------------------------------------------

const CALL_MENU_OPTIONS = [
    {
      label: '+0 124 344 678'
    },
    {
      label: '+0 124 344 678'
    },
    {
      label: '+0 124 344 678'
    },
  ];

  // ----------------------------------------------------------------------
  export default function CallAnytimeBtn() {
    const [open, setOpen] = useState(null);
  
    const handleOpen = (event) => {
      setOpen(event.currentTarget);
    };
  
    const handleClose = () => {
      setOpen(null);
    };
    return (
        <>
          <IconButton
            onClick={handleOpen}
            sx={{
              borderRadius: '0',
              p: 0,
              ...(open && {'&:before': {
                  zIndex: 1,
                  content: "''",
                  width: '100%',
                  height: '100%',
                  position: 'absolute',
                  bgcolor: (theme) => alpha(theme.palette.grey[500], 0.12),
                },
              }),
            }}
          >
            <Iconify icon="ph:phone-fill" />
            <Box sx={{ my: 1.5, px: 3 }}>
              <Typography variant="subtitle2" noWrap>
                {<FormattedMessage id="lbl.callAnytime.button.header"/>}
              </Typography>
            </Box>
          </IconButton>
    
          <Popover
            open={Boolean(open)}
            anchorEl={open}
            onClose={handleClose}
            anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
            transformOrigin={{ vertical: 'top', horizontal: 'right' }}
            PaperProps={{
              sx: {
                p: 0,
                mt: 1.5,
                ml: 0.75,
                width: 180,
                '& .MuiMenuItem-root': {
                  typography: 'body2',
                  borderRadius: 0.75,
                },
              },
            }}
          >
            <Divider sx={{ borderStyle: 'dashed' }} />
    
            <Stack sx={{ p: 1 }}>
              {CALL_MENU_OPTIONS.map((option) => (
                <MenuItem key={option.label}>
                  {option.label}
                </MenuItem>
              ))}
            </Stack>
    
            <Divider sx={{ borderStyle: 'dashed' }} />
          </Popover>
        </>
      );  
    }
