import { Outlet } from 'react-router-dom';
// @mui
import { styled } from '@mui/material/styles';
// components
import Header from './header';
import Footer from './footer/footer'
// ----------------------------------------------------------------------

const APP_BAR_MOBILE = 64;
const APP_BAR_DESKTOP = 92;

const StyledHeader = styled('header')(({ theme }) => ({
  top: 0,
  left: 0,
  lineHeight: 0,
  width: '100%',
  position: 'center',
  // padding: theme.spacing(0, 0, 0),
  // [theme.breakpoints.up('sm')]: {
  //   padding: theme.spacing(0, 0, 0),
  // },
}));

const Main = styled('div')(({ theme }) => ({
  flexGrow: 1,
  // overflow: 'auto',
  minHeight: '100%',
  paddingTop: APP_BAR_MOBILE + 24,
  // paddingBottom: theme.spacing(10),
  // [theme.breakpoints.up('lg')]: {
  //   paddingTop: APP_BAR_DESKTOP + 24,
  //   paddingLeft: theme.spacing(0),
  //   paddingRight: theme.spacing(0),
  // },
}));

// ----------------------------------------------------------------------

export default function SimpleLayout() {
  return (
    <>
        <StyledHeader sx= {{display: "flex",  position: 'fixed', backgroundColor: 'white', zIndex: 999}}>
          <Header />
        </StyledHeader>

        <Main>
          <Outlet />
        </Main>
        
        <Footer/>
    </>
  );
}
