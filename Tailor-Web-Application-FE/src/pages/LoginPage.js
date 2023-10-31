import { Helmet } from 'react-helmet-async';
// @mui
import { styled } from '@mui/material/styles';
import { Link, Box, Container, Typography, Divider, Stack, Button } from '@mui/material';
import { FormattedMessage } from 'react-intl';

// hooks
import useResponsive from '../hooks/useResponsive';
// components
import logoLogin from '../assets/logoLogin.jpg';
import Iconify from '../components/iconify';
// sections
import { LoginForm } from '../sections/auth/login';
import LoginImage from '../assets/ContactUsImage.jpg';

// ----------------------------------------------------------------------

const StyledRoot = styled('div')(({ theme }) => ({
  [theme.breakpoints.up('md')]: {
    display: 'flex',
  },
}));

const StyledSection = styled('div')(({ theme }) => ({
  width: '100%',
  maxWidth: 480,
  display: 'flex',
  flexDirection: 'column',
  justifyContent: 'center',
  boxShadow: theme.customShadows.card,
  // backgroundColor: theme.palette.background.default,
  backgroundColor: '#454456',
}));

const StyledContent = styled('div')(({ theme }) => ({
  maxWidth: 480,
  margin: 'auto',
  minHeight: '100vh',
  display: 'flex',
  justifyContent: 'center',
  flexDirection: 'column',
  padding: theme.spacing(12, 0),
}));

// ----------------------------------------------------------------------

export default function LoginPage() {
  const mdUp = useResponsive('up', 'md');

  return (
    <>
      <Helmet>
        <title> Login | Tailor Web App</title>
      </Helmet>

      <StyledRoot sx = {{ backgroundColor: '#DEB18A'}}>
        <img src = 'logoLogin' alt = ""/>

        {mdUp && (
          <StyledSection>
            <Typography color = "white" variant="h3" sx={{ px: 5, mt: 10, mb: 5 }}>
            <FormattedMessage id="lbl.login.welcome"/>
            </Typography>
            <Box sx = {{
              height: '500px',
              overflow: 'hidden',
            }}>
              <img src={LoginImage} alt="login" style = {{objectFit: 'cover'}}/>
            </Box>
            
          </StyledSection>
        )}

        <Container maxWidth="sm">
          <StyledContent>
            <Typography variant="h4" gutterBottom>
            <FormattedMessage id="lbl.login.login"/>
            </Typography>

            <LoginForm />
          </StyledContent>
        </Container>
      </StyledRoot>
    </>
  );
}
