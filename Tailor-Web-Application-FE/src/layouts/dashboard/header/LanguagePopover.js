import { useState, useContext } from 'react';
// @mui
import { alpha } from '@mui/material/styles';
import { Box, MenuItem, Stack, IconButton, Popover } from '@mui/material';

import { TWAIntlContext } from '../../../contexts';

// ----------------------------------------------------------------------

// ----------------------------------------------------------------------

export default function LanguagePopover() {
  const [open, setOpen] = useState(null);
  const { locale, nextLanguage, switchLanguage } = useContext(TWAIntlContext);

  const handleOpen = (event) => {
    setOpen(event.currentTarget);
  };

  const handleClose = () => {
    setOpen(null);
  };

  const LANGS = [
    {
      value: 'ro',
      label: 'Romana',
      icon: '/assets/icons/ic_flag_ro.svg',
      onClick() {
        handleClose();
        switchLanguage(nextLanguage(locale));
      }
    },
    {
      value: 'en',
      label: 'English',
      icon: '/assets/icons/ic_flag_en.svg',
      onClick() {
        handleClose();
        switchLanguage(nextLanguage(locale));
      }
    },
  ];

console.log(LANGS.filter(lang => lang.value === locale)[0].icon);
  return (
    <>
      <IconButton
        onClick={handleOpen}
        sx={{
          padding: 0,
          width: 44,
          height: 44,
          ...(open && {
            bgcolor: (theme) => alpha(theme.palette.primary.main, theme.palette.action.focusOpacity),
          }),
        }}
      >
        <img src={LANGS.filter(lang => lang.value === locale)[0].icon} alt={LANGS[0].label} />
      </IconButton>

      <Popover
        open={Boolean(open)}
        anchorEl={open}
        onClose={handleClose}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
        transformOrigin={{ vertical: 'top', horizontal: 'right' }}
        PaperProps={{
          sx: {
            p: 1,
            mt: 1.5,
            ml: 0.75,
            width: 180,
            '& .MuiMenuItem-root': {
              px: 1,
              typography: 'body2',
              borderRadius: 0.75,
            },
          },
        }}
      >
        <Stack spacing={0.75}>
          {LANGS.map((option) => (
             <MenuItem key={option.value} selected={option.value === locale} onClick={() => option.value !== locale && option.onClick()}>

            <Box component="img" alt={option.label} src={option.icon} sx={{ width: 28, mr: 2 }} />

              {option.label}
            </MenuItem>
          ))}
        </Stack>
      </Popover>
    </>
  );
}
