/* eslint-disable import/named */
/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { FormattedMessage, useIntl } from 'react-intl';
import { Helmet } from 'react-helmet-async';
import { filter } from 'lodash';

// @mui
import {
  Card,
  Table,
  Stack,
  Paper,
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
} from '@mui/material';
// components
import Iconify from '../../components/iconify';
import Scrollbar from '../../components/scrollbar';

import {
  BasicModal,
  AppointmentModal,
} from '../../components/modals';

// sections
import { AppointmentListToolbar, AppointmentListHead } from '../../sections/@dashboard/appointments';
import { ErrorDescription } from '../../components'
// data
import tailorList from '../../_mock/tailorList';
import { 
  setAppointmentError,
  setAppointmentStatus,
  setSelectedAppointment,
  getAppointments,
  setNewAppointmentStatus,
  newAppointment,
  setDeleteAppointmentStatus,
  setUpdateAppointmentStatus,
  deleteAppointment,
} from '../../config/redux/slices/AppointmentsSlice';

// ----------------------------------------------------------------------

const TABLE_HEAD = [
  { id: 'customerName', label: 'Customer Name', alignRight: false },
  { id: 'customerEmail', label: 'Customer Email', alignRight: false },
  { id: 'customerPhone', label: 'Customer Phone', alignRight: false },
  { id: 'appointmentDate', label: 'Appointment Date', alignRight: false },
  { id: 'appointmentStartTime', label: 'Appointment Start Time', alignRight: false },
  { id: '' },
];

// ----------------------------------------------------------------------

function descendingComparator(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function getComparator(order, orderBy) {
  return order === 'desc'
    ? (a, b) => descendingComparator(a, b, orderBy)
    : (a, b) => -descendingComparator(a, b, orderBy);
}

function applySortFilter(array, comparator, query) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = comparator(a[0], b[0]);
    if (order !== 0) return order;
    return a[1] - b[1];
  });
  if (query) {
    return filter(array, (_user) => _user.customerName.toLowerCase().indexOf(query.toLowerCase()) !== -1);
  }
  return stabilizedThis.map((el) => el[0]);
}

export default function AppointmentDashboardPage() {

  const [open, setOpen] = useState(null);

  const [page, setPage] = useState(0);

  const [order, setOrder] = useState('asc');

  const [selected, setSelected] = useState([]);

  const [orderBy, setOrderBy] = useState('name');

  const [filterName, setFilterName] = useState('');

  const [rowsPerPage, setRowsPerPage] = useState(5);

  const [showConfirmation, setShowConfirmation] = useState(false);

  const [filteredAppointments, setFilteredAppointments] = useState([]);

  const intl = useIntl();

  const [showModal, setShowModal] = useState(false);  

  const [selectedRowAppointment, setSelectedRowAppointment] = useState(null);

  const [ isEdit, setIsEdit] = useState(false);
  
  const dispatch = useDispatch();

  const [error, setError] = useState(null);

  const emptyRows = page > 0 ? Math.max(0, (1 + page) * rowsPerPage - tailorList.length) : 0;

  const isNotFound = !filteredAppointments.length && !!filterName;

  const {
    loading,
    selectedAppointment,
    appointments,
    appointmentError,
    appointments_status,
    new_appointments_status,
    delete_appointment_status,
    update_appointment_status,
  } = useSelector((state) => state.appointments)

  useEffect(() => {
    if (appointments && appointments.length > 0) {
  const updatedFilteredAppointments = applySortFilter(appointments, getComparator(order, orderBy), filterName);
  setFilteredAppointments(updatedFilteredAppointments);
  }}, [appointments, order, orderBy, filterName]);

  useEffect(() => {
    dispatch(setSelectedAppointment(appointments?.filter((appointment) => appointment.id === selectedAppointment?.id)[0]));
  }, [appointments, dispatch]);

  useEffect(() => {
    if (delete_appointment_status === 'success') {
      dispatch(setDeleteAppointmentStatus(null));
      dispatch(getAppointments());
    }
    if (delete_appointment_status === 'failed' && appointmentError) {
      setError(true);
    }
  }, [delete_appointment_status, appointmentError, dispatch]);

  useEffect(() => {
    if (update_appointment_status === 'success') {
      dispatch(setUpdateAppointmentStatus(null));
      dispatch(getAppointments());
    }
    if (update_appointment_status === 'failed' && appointmentError) {
      setError(true);
    }
  }, [update_appointment_status, appointmentError, dispatch]);

  useEffect(() => {
    if(!appointments && !(appointments_status === 'failed')) 
    {
      dispatch(getAppointments());
    }
    if(appointments_status === 'failed' && appointmentError) {
      setError(true);
    }
    if(appointments && appointmentError && appointments_status === 'failed')
    {
      dispatch(setAppointmentError(null));
      dispatch(setAppointmentStatus(null));
    }
  }, [appointments, appointments_status, dispatch, appointmentError]);

  useEffect(() => {
    if (appointmentError && new_appointments_status === 'failed') {
      setError(true);
    }

    if (new_appointments_status === 'success') {
      dispatch(getAppointments());
      dispatch(setNewAppointmentStatus(null));
    }
  }, [appointmentError, new_appointments_status, dispatch]); 

  const handleOpenMenu = (event, row) => {
    setOpen(event.currentTarget);
    setSelectedRowAppointment(row)
    handleError();
  };

  const handleCloseMenu = () => {
    setOpen(null);
  };

  const handleRequestSort = (event, property) => {
    const isAsc = orderBy === property && order === 'asc';
    setOrder(isAsc ? 'desc' : 'asc');
    setOrderBy(property);
  };

  const handleSelectAllClick = (event) => {
    if (event.target.checked) {
      const newSelecteds = tailorList.map((n) => n.name);
      setSelected(newSelecteds);
      return;
    }
    setSelected([]);
  };

  const handleClick = (event, name) => {
    const selectedIndex = selected.indexOf(name);
    let newSelected = [];
    if (selectedIndex === -1) {
      newSelected = newSelected.concat(selected, name);
    } else if (selectedIndex === 0) {
      newSelected = newSelected.concat(selected.slice(1));
    } else if (selectedIndex === selected.length - 1) {
      newSelected = newSelected.concat(selected.slice(0, -1));
    } else if (selectedIndex > 0) {
      newSelected = newSelected.concat(selected.slice(0, selectedIndex), selected.slice(selectedIndex + 1));
    }
    setSelected(newSelected);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setPage(0);
    setRowsPerPage(parseInt(event.target.value, 10));
  };

  const handleFilterByName = (event) => {
    setPage(0);
    setFilterName(event.target.value);
  };

  const handleRemove = () => {
    setShowConfirmation(true);
  };

  const handleOnClose = () => {
    setShowModal(false);
  };  

  const handleError = () => {
    setError(false);
    dispatch(setAppointmentError(null));
    dispatch(setNewAppointmentStatus(null));
    dispatch(setDeleteAppointmentStatus(null));
    dispatch(setUpdateAppointmentStatus(null));
  };

  const onConfirmDeleteAppointment = () => {
    dispatch(deleteAppointment(selectedRowAppointment.id));
    setShowConfirmation(false);
  };

  const onAddClick = () => {
    setIsEdit(false);
    setShowModal(true);
  };
  
  const onEditClick = () => {
    setIsEdit(true);
    setShowModal(true);
  };

  const onSelectedAppointment = (appointments) => {
    dispatch(setSelectedAppointment(appointments));
  };


  const addNewAppointment = (appointments) => {
    setShowModal(false);
    const appointmentRequest = {
      customerName: appointments.customerName,
      customerEmail: appointments.customerEmail,
      customerPhone: appointments.customerPhone,
      appointmentDate: appointments.appointmentDate,
      appointmentStartTime: appointments.appointmentStartTime,
      notes: appointments.notes,
    };

    console.log("appointmentRequest" , appointmentRequest);
    dispatch(newAppointment(appointmentRequest));
  };

  const editAppointment = (appointments) => {
    setShowModal(false);
    const appointmentRequest = {
      id: appointments.id,
      customerName: appointments.customerName,
      customerEmail: appointments.customerEmail,
      customerPhone: appointments.customerPhone,
      appointmentDate: new Date(),
      notes: appointments.notes,
    };
    console.log("appointmentRequest" , appointmentRequest);
    
    dispatch(editAppointment(appointmentRequest));
  };

  return (
    <>
      <Helmet>
        <title> Appointments | Tailor Web App </title>
      </Helmet>

      <Container sx = {{backgroundColor: '#454456', borderRadius: '10px', py: '10px'}}>
        <Stack direction="row" alignItems="center" justifyContent="space-between" mb={5}  >
          <Typography variant="h4" gutterBottom color= "white">
            Programari
          </Typography>
          <Button variant="contained" startIcon={<Iconify icon="eva:plus-fill" />} onClick = {onAddClick}>
            Programare noua
          </Button>
        </Stack>

        {
          filteredAppointments?.length > 0 &&
          <Card >
          <AppointmentListToolbar numSelected={selected.length} filterName={filterName} onFilterName={handleFilterByName} />

          <Scrollbar>
            <TableContainer sx={{ minWidth: 800 }}>
              <Table>
                <AppointmentListHead
                  order={order}
                  orderBy={orderBy}
                  headLabel={TABLE_HEAD}
                  rowCount={filteredAppointments.length}
                  numSelected={selected.length}
                  onRequestSort={handleRequestSort}
                  onSelectAllClick={handleSelectAllClick}
                />
                <TableBody>
                  {filteredAppointments.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((row) => {
                    const { id, customerName,customerEmail, customerPhone, appointmentDate, appointmentStartTime} = row;
                    const selectedUser = selected.indexOf(customerName) !== -1;
                    const appDate = new Date(appointmentDate);
                    const formattedDate = appDate.toLocaleString('en-GB', {day: '2-digit', month: 'short', year: 'numeric'});
                    const formattedTime = appDate.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
                    return (
                      <TableRow hover key={id} tabIndex={-1} role="checkbox" selected={selectedUser}>
                        <TableCell padding="checkbox">
                          <Checkbox checked={selectedUser} onChange={(event) => handleClick(event, customerName)} />
                        </TableCell>

                        <TableCell component="th" scope="row" padding="none">
                          <Stack direction="row" alignItems="center" spacing={2}>
                            <Typography variant="subtitle2" noWrap>
                              {customerName}
                            </Typography>
                          </Stack>
                        </TableCell>

                        <TableCell align="left">{customerEmail}</TableCell>

                        <TableCell align="left">{customerPhone}</TableCell>

                        <TableCell align="left">{formattedDate}</TableCell>

                        <TableCell align="left">{formattedTime}</TableCell>


                        <TableCell align="right">
                          <IconButton size="large" color="inherit" onClick={event => handleOpenMenu(event, row)}>
                            <Iconify icon={'eva:more-vertical-fill'} />
                          </IconButton>
                        </TableCell>

                      </TableRow>
                    );
                  })}
                  {emptyRows > 0 && (
                    <TableRow style={{ height: 53 * emptyRows }}>
                      <TableCell colSpan={6} />
                    </TableRow>
                  )}
                </TableBody>

                {isNotFound && (
                  <TableBody>
                    <TableRow>
                      <TableCell align="center" colSpan={6} sx={{ py: 3 }}>
                        <Paper
                          sx={{
                            textAlign: 'center',
                          }}
                        >
                          <Typography variant="h6" paragraph>
                            Not found
                          </Typography>

                          <Typography variant="body2">
                            No results found for &nbsp;
                            <strong>&quot;{filterName}&quot;</strong>.
                            <br /> Try checking for typos or using complete words.
                          </Typography>
                        </Paper>
                      </TableCell>
                    </TableRow>
                  </TableBody>
                )}
              </Table>
            </TableContainer>
          </Scrollbar>

          <TablePagination
            rowsPerPageOptions={[5, 10, 25]}
            component="div"
            count={appointments.length}
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={handleChangePage}
            onRowsPerPageChange={handleChangeRowsPerPage}
          />
        </Card>
        }
       
      </Container>

      <Popover
        open={Boolean(open)}
        anchorEl={open}
        onClose={handleCloseMenu}
        anchorOrigin={{ vertical: 'top', horizontal: 'left' }}
        transformOrigin={{ vertical: 'top', horizontal: 'right' }}
        PaperProps={{
          sx: {
            p: 1,
            width: 140,
            '& .MuiMenuItem-root': {
              px: 1,
              typography: 'body2',
              borderRadius: 0.75,
            },
          },
        }}
      >
        <MenuItem
>
          <Iconify icon={'eva:edit-fill'} sx={{ mr: 2 }} onClick={onEditClick}/>
          Edit
        </MenuItem>

        <MenuItem sx={{ color: 'error.main' }}>
          <Iconify icon={'eva:trash-2-outline'} sx={{ mr: 2 }} onClick={handleRemove}/>
          Delete
        </MenuItem>
      </Popover>

      {showModal && <AppointmentModal 
          open={showModal} 
          onClose={handleOnClose} 
          onSubmit={isEdit ? editAppointment : addNewAppointment} content = {isEdit ? selectedRowAppointment : null}
        />}

      {showConfirmation && (
        <BasicModal
          isError
          open={showConfirmation}
          onClose={() => setShowConfirmation(false)}
          title={intl.formatMessage({ id:"lbl.delete-confirmation"})}
          onSubmit={() => setShowConfirmation(false)}
          save= {intl.formatMessage({ id: "lbl.button.ok" })}
        />)}

      {error && (
        <BasicModal
          isError
          open={error}
          onClose={handleError}
          title={appointmentError && <ErrorDescription error={appointmentError} />}
          onSubmit={handleError}
          save='btn.ok'
        />
      )}
    </>
  );
}
