import { FormattedMessage, useIntl } from 'react-intl';
import { Helmet } from 'react-helmet-async';
import { useSelector, useDispatch } from 'react-redux';
import { filter } from 'lodash';
import { sentenceCase } from 'change-case';
import { useState } from 'react';
import Storage from 'store2';
import * as Yup from 'yup';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';

// @mui
import {
  Box,
  Card,
  Table,
  Stack,
  Paper,
  Avatar,
  Button,
  Popover,
  Checkbox,
  TableRow,
  MenuItem,
  TableBody,
  TableCell,
  Container,
  Typography,
  IconButton,
  TableContainer,
  TablePagination,
  TextField,
} from '@mui/material';
// components
import Label from '../../components/label';
import Iconify from '../../components/iconify';
import Scrollbar from '../../components/scrollbar';

import { UserModal } from '../../components/modals';
// sections
import { UserListHead, UserListToolbar } from '../../sections/@dashboard/user';
// mock
import USERLIST from '../../_mock/user';
import tailorList from '../../_mock/tailorList';

// ----------------------------------------------------------------------

const TABLE_HEAD = [
  { id: 'name', label: 'Name', alignRight: false },
  { id: 'role', label: 'Role', alignRight: false },
  { id: 'isVerified', label: 'Verified', alignRight: false },
  { id: 'status', label: 'Status', alignRight: false },
  { id: '' },
];

// ----------------------------------------------------------------------

export default function ProfileDashboardPage() {
  const [showModal, setShowModal] = useState(false);  

    const account = {
        email: Storage.get('email'),
        photoURL:Storage.get('profileImg') ,
        displayName: Storage.get('name') ,
    };
    
    const defaultInputValues = {
        name: account ? account.displayName : '',
        photoURL: account? account.photoURL: '',
        email: account ? account.event: '',
    };

    const [showConfirmation, setShowConfirmation] = useState(false);

    const [editMode, setEditMode] = useState(false);

    const handleClick = () => {
      setEditMode(!editMode);
    };
    const onEditClick = () => {
      setShowModal(true);
    };
    const handleOnClose = () => {
      setShowModal(false);
    };

  const intl = useIntl();

  const handleRemove = () => {
    setShowConfirmation(true);
  };
  const onConfirmEditStaff = () => {
    // dispatch(deleteNews(selectedNews.id));
    setShowConfirmation(false);
  };

  return (
    <>
      <Helmet>
        <title> User | Tailor Web App </title>
      </Helmet>

      <Container sx = {{backgroundColor: '#454456', borderRadius: '10px', py: '10px'}}>
        <Stack direction="row" alignItems="center" justifyContent="space-between" mb={5}  >
          <Typography variant="h4" gutterBottom color= "white">
            User
          </Typography>
        </Stack>

        <Card sx = {{display: 'flex', flexDirection: 'row', p: '20px', width:'40rem'}}>
            <Box sx = {{display: 'flex', 
                overflow: 'hidden', 
                borderRadius: '50%', 
                width: '250px', 
                height: '250px'}}> 

                <img alt={account.displayName} src={account.photoURL} style={{ objectFit: 'cover' }}/> 
            </Box>

            <Box sx = {{ flexDirection: 'column', justifyContent: 'space-between', my: '10px', mx: '50px', }}>
                <Box sx = {{ display:'flex', flexDirection: 'column', }}>
                    <Label sx = {{mb: '3px'}}> Nume: </Label>
                    <Label sx = {{mb: '3px', height:'53px', fontSize: '15px'}}> {account.displayName} </Label>
                </Box>

                <Box sx = {{ display:'flex', flexDirection: 'column', }}>
                    <Label sx = {{mb: '3px'}}> Email: </Label>
                    <Label sx = {{mb: '3px', height:'53px', fontSize: '15px'}}> {account.email} </Label>
                </Box>

                <Box sx = {{display: 'flex', flexDirection:'row'}}>
                <Button variant="contained" startIcon={<Iconify icon="eva:plus-fill" />} onClick={onEditClick}>
                    Editeaza contul
                </Button>
                </Box>
            </Box>
        </Card>
      </Container>

      {showModal && <UserModal open={showModal} onClose={handleOnClose} content={account}/>}
    </>
  );
}
