import { BrowserRouter } from 'react-router-dom';
import { HelmetProvider } from 'react-helmet-async';
import { Provider } from 'react-redux';
// routes
import Router from './routes';
// theme
import ThemeProvider from './theme';
// components
import { StyledChart } from './components/chart';
import ScrollToTop from './components/scroll-to-top';
import { TWAIntlProvider } from './contexts/TWAIntlContext';
import store from './config/redux/store';

// ----------------------------------------------------------------------

export default function App() {
  return (
    <TWAIntlProvider>
        <HelmetProvider>
          <BrowserRouter>
            <ThemeProvider>
              <Provider store = {store}>
                <ScrollToTop />
                <StyledChart />
                <Router />
              </Provider>
            </ThemeProvider>
          </BrowserRouter>
        </HelmetProvider>
    </TWAIntlProvider>
  );
}
