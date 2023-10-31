// component
import Iconify from '../../../components/iconify';
// ----------------------------------------------------------------------

const icon = (name) => <Iconify icon={`${name}`} sx={{ width: 1, height: 1 }} />;

const footerNavConfig = [
  {
    title: 'home',
    path: '/app/home',
    icon: icon("tabler:home"),
  },
  {
    title: 'about',
    path: '/app/about',
    icon: icon('mdi:about'),
  },
  {
    title: 'services',
    path: '/app/services',
    icon: icon('mdi:scissors'),
  },
  {
    title: 'blog',
    path: '/app/blog',
    icon: icon('mdi:blog'),
  },
  {
    title: 'contact',
    path: '/app/contact',
    icon: icon('mdi:contact-outline'),
  },
];

export default headNavConfig;
