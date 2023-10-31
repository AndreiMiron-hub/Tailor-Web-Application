import React, { useState, useMemo } from 'react';
import { useIntl } from 'react-intl';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';

import { Box, TextField, MenuItem, Button, Select } from '@mui/material';

import BasicModal from './BasicModal';
import { UploadImage } from '../uploadImage';
import { ProductStatus } from '../productStatus';

const ProductModal = ({ open, onClose, content = null, addNewProduct }) => {
  const intl = useIntl();
  const [isImageSelected, setIsImageSelected] = useState(content ? true : null);

  const generateHashTags = (hashtags) => {
    if (!hashtags || hashtags.length === 0) return [];

    return hashtags?.map((hashtag) => {
      return { id: hashtag, text: hashtag };
    });
  };

  const sizes = [
    { id: 1, name: 'XXS' },
    { id: 2, name: 'XS' },
    { id: 3, name: 'S' },
    { id: 4, name: 'M' },
    { id: 5, name: 'L' },
    { id: 6, name: 'XL' },
    { id: 7, name: 'XXL' },
    { id: 8, name: 'XXXL' }
  ];

  const categories = [
    { id: 1, name: 'Costum' },
    { id: 2, name: 'Vesta' },
    { id: 3, name: 'Pantalon' },
    { id: 4, name: 'Camasa' },
    { id: 5, name: 'Batista' },
    { id: 6, name: 'Cravata' },
    { id: 7, name: 'Papion' },
  ];

  const hashtags = useMemo(() => generateHashTags(content?.hashtags), [content?.hashtags]);

  const defaultInputValues = {
    name: content ? content.name : '',
    color: content ? content.color : '',
    material: content ? content.material : '',
    price: content ? content.price : '',
    description: content ? content.description : '',
    quantity: content ? content.quantity : '',
    category: content ? content.category : '',
    size: content ? content.size : '',
    status: content ? content.status: '',
  };

  const [values, setValues] = useState(defaultInputValues);

  const validationSchema = Yup.object().shape({
    name: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.title-required' })} ${intl.formatMessage({
        id: 'lbl.is-required',
      })}`,
    ),
    // description: Yup.string().required(
    //   `${intl.formatMessage({ id: 'lbl.staff-description-required' })} ${intl.formatMessage({
    //     id: 'lbl.is-height-required',
    //   })}`,
    // ),
    text: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.text-required' })} ${intl.formatMessage({
        id: 'lbl.is-required',
      })}`,
    ),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    mode: 'onTouched',
    reValidateMode: 'onTouched',
    defaultValues: defaultInputValues,
    resolver: yupResolver(validationSchema),
  });

  const addProduct = () => {
    addNewProduct(values);
  };

  const handleChange = (value) => {
    setValues(value);
  };

  const addArticle = () => {
    if (!isImageSelected) {
      setIsImageSelected(false);
      return;
    }
    
    setIsImageSelected(null);
  };

  const getContent = () => (
    <Box
  sx={{
    display: 'flex',
    alignItems: ['center', 'initial', 'initial'],
    flexDirection: 'column',
    '.MuiFormControl-root': {
      mb: '20px',
      color: 'white',
    },
  }}
>
<TextField
  placeholder={intl.formatMessage({ id: 'lbl.name' })}
  name="name"
  label={intl.formatMessage({ id: 'lbl.name' })}
  required
  {...register('name')}
  error={!!errors.name}
  helperText={errors.name?.message}
  value={values.name}
  onChange={(event) => handleChange({ ...values, name: event.target.value })}
  InputProps={{
    style: { color: 'white' },
  }}
/>

  <TextField
    placeholder={intl.formatMessage({ id: "lbl.product.description" })}
    name="description"
    label={intl.formatMessage({ id: "lbl.product.description" })}
    required
    {...register('description')}
    error={!!errors.description}
    helperText={errors.description?.message}
    value={values.description}
    onChange={(event) => handleChange({ ...values, description: event.target.value })}
    InputProps={{
      style: { color: 'white' },
    }}
  />

<Box sx = {{
    display: 'flex',
    flexDirection :'row',
    justifyContent: 'space-between',
}}> 
    <TextField
        placeholder={intl.formatMessage({ id: "lbl.product.color" })}
        name="color"
        label={intl.formatMessage({ id: "lbl.product.color" })}
        required
        {...register('color')}
        error={!!errors.color}
        helperText={errors.color?.message}
        value={values.color}
        onChange={(event) => handleChange({ ...values, color: event.target.value })}
        InputProps={{
        style: { color: 'white' },
        }}
    />

<TextField
        placeholder={intl.formatMessage({ id: "lbl.product.material" })}
        name="material"
        label={intl.formatMessage({ id: "lbl.product.material" })}
        required
        {...register('material')}
        error={!!errors.material}
        helperText={errors.material?.message}
        value={values.material}
        onChange={(event) => handleChange({ ...values, material: event.target.value })}
        InputProps={{
        style: { color: 'white' },
        }}
    />



<TextField
        placeholder={intl.formatMessage({ id: "lbl.product.price" })}
        name="price"
        label={intl.formatMessage({ id: "lbl.product.material" })}
        required
        {...register('price')}
        error={!!errors.price}
        helperText={errors.price?.message}
        value={values.price}
        onChange={(event) => handleChange({ ...values, price: event.target.value })}
        InputProps={{
        style: { color: 'white' },
        }}
    />
    </Box>
<Box sx = {{
    display: 'flex',
    justifyContent: 'space-between',
    height: '100px',
    mb: '150px',
}}> 
<TextField
        placeholder={intl.formatMessage({ id: "lbl.product.quantity" })}
        name="quantity"
        label={intl.formatMessage({ id: "lbl.product.quantity" })}
        required
        {...register('quantity')}
        error={!!errors.quantity}
        helperText={errors.quantity?.message}
        value={values.quantity}
        onChange={(event) => handleChange({ ...values, quantity: event.target.value })}
        style = {{ width : '33%'}}
        InputProps={{
        style: { color: 'white' },
        }}
    />


<TextField
        name="category"
        label={intl.formatMessage({ id: "lbl.product.category" })}
        select
        {...register('category')}
        error={!!errors.category}
        helperText={errors.category?.message}
        value={values.category}
        onChange={(event) => handleChange({ ...values, category: event.target.value })}
        style = {{ width : '33%'}}
        InputProps={{
            style: { color: 'white' },
            }}
        >

        {categories?.map((category) => (
          <option key={category.id} value={category.name}>
            {category.name}
          </option>
        ))}
        </TextField>

<TextField
        {...register('size')}
        name='size'
        label={intl.formatMessage({ id: "lbl.product.size" })}
        select
        error={!!errors.size}
        helperText={errors.size?.message}
        value={values.size}
        onChange={(event) => handleChange({ ...values, size: event.target.value })}
        style = {{ width : '33%'}}
        InputProps={{
            style: { color: 'white' },
            }}
      >
        {sizes?.map((size) => (
          <option key={size.id} value={size.name}>
            {size.name}
          </option>
        ))}
      </TextField>
</Box>


  <UploadImage
    name="content"
    values={values}
    setValues={setValues}
    isSelected={isImageSelected}
    setIsSelected={setIsImageSelected}
    errors={errors}
  />

  <ProductStatus values={values} setValues={setValues} />
</Box>
  );

  return (
    <BasicModal
      open={open}
      onClose={onClose}
      title={intl.formatMessage({ id: 'lbl.add-news' })}
      content={getContent()}
      onSubmit={onClose}
      save={content ? 'btn.save' : 'btn.add'}
      width='50rem'
      typographyProps={{ textAlign: 'center' }}
    />
  );
};

export default ProductModal;
