import { FormattedMessage } from 'react-intl';
// @mui
import { styled } from '@mui/material/styles';
import { Box, Stack, Toolbar} from '@mui/material';
import { NavLink as RouterLink } from 'react-router-dom';
// utils

// components

//
import LanguagePopover from '../../dashboard/header/LanguagePopover';
import Searchbar from '../../dashboard/header/Searchbar';
import Navigation from './navigation';
import headNavConfig from './config'; 
import CallAnytimeBtn from './CallAnytimeBtn';
import logo from '../../../assets/logo-black.png';

// ----------------------------------------------------------------------

const HEADER_MOBILE = 64;

const HEADER_DESKTOP = 92;

const StyledToolbar = styled(Toolbar)(({ theme }) => ({
  minHeight: HEADER_MOBILE,
  [theme.breakpoints.up('lg')]: {
    minHeight: HEADER_DESKTOP,
    padding: theme.spacing(0, 5),
  },
}));

// ----------------------------------------------------------------------

export default function Header() {
    return (
        <StyledToolbar>
          <Box sx={{ flexGrow: 1 }} />
  
          <Stack
            direction="row"
            alignItems="center"
            spacing={{
              xs: 0.5,
              sm: 3,
            }}
          >
            <Box 
                component={RouterLink}
                to={'/home'}
                sx={{height:'80px',width: '105px', px: 2.5, py: 1, display: 'inline-flex'}}>
              <img 
                src = {logo} 
                alt = "" 
                height = '75px'
              />
            </Box>

            <Navigation data={headNavConfig} />
            <CallAnytimeBtn/>
            <Searchbar/> 
            <LanguagePopover />
            
            <Box component={RouterLink}
                  to={'/appointment'}   
              sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                height: '60px',
                width: '11rem',
                backgroundColor: '#DEB18A',
                color: 'white',
                borderRadius: '7px',
                fontSize: '22px',
                textDecoration: 'none',
            }}>
             <FormattedMessage id="lbl.appointment.button.header"/>  
            </Box>

          </Stack>
        </StyledToolbar>
    );
}