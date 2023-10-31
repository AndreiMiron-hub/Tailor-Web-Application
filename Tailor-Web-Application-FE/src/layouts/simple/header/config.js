import { FormattedMessage } from 'react-intl';

// component
import Iconify from '../../../components/iconify';
// ----------------------------------------------------------------------

const icon = (name) => <Iconify icon={`${name}`} sx={{ width: 1, height: 1 }} />;

const headNavConfig = [
  {
    key: 'home',
    title: <FormattedMessage id="lbl.home.header"/>,
    path: '/home',
    icon: icon("tabler:home"),
  },
  {
    key: 'about',
    title: <FormattedMessage id="lbl.about.header"/>,
    path: '/about',
    icon: icon('mdi:about'),
  },
  {
    key: 'services',
    title: <FormattedMessage id="lbl.services.header"/>,
    path: '/services',
    icon: icon('mdi:scissors'),
  },
  {
    key: 'blog',
    title: <FormattedMessage id="lbl.blog.header"/>,
    path: '/blog',
    icon: icon('mdi:blog'),
  },
  {
    key: 'contact',
    title: <FormattedMessage id="lbl.contact.header"/>,
    path: '/contact',
    icon: icon('mdi:contact-outline'),
  },
  {
    key: 'products',
    title: <FormattedMessage id="lbl.products.title"/>,
    path: '/products',
    icon: icon('icon-park-outline:clothes-cardigan'),
  },
];

export default headNavConfig;
