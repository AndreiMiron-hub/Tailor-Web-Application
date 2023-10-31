import React, { useState, useEffect } from 'react';

// @mui
import { Grid } from '@mui/material';
import ShopProductCard from './ProductCard';
// ----------------------------------------------------------------------

// ProductList.propTypes = {
//   products: PropTypes.array.isRequired,
// };

export default function ProductList({ products, loading, onSelected, ...other }) {
  return (
    <Grid container spacing={3} marginBottom={2} {...other}>
      {!loading && 
          products &&
            products.slice(0,40).map((product, index) =>{
              return <Grid key={product.id} item xs={12} sm={6} md={3}>
                      <ShopProductCard key = {index + product.id} product={product} onSelected={onSelected}/>
                    </Grid>
        })}

    </Grid>
  );
}
