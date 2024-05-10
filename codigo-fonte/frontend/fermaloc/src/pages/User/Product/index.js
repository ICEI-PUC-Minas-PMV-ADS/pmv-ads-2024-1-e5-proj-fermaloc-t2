import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

// Estilização
import styles from "./styles.module.css";

// Serviço
import {
  getProductById,
  getSimalarProducts,
} from "../../../services/productService";

// Components
import SimilarProduct from "./components/SimilarProduct/index.js";
import Title from "../../../components/Title/index.js";

export default function Product() {
  const { id } = useParams();
  const [product, setProduct] = useState({});
  const [similarProducts, setSimilarProducts] = useState([]);

  useEffect(() => {
    async function fetchProductAndSimilarProducts(id) {
      const productData = await getProductById(id);
      const simiularProductsData = await getSimalarProducts(
        id,
        productData.categoryDto.id
      );
      setProduct(productData);
      console.log(simiularProductsData);
      setSimilarProducts(simiularProductsData);
    }
    fetchProductAndSimilarProducts(id);
  }, [id]);

  return (
    <div className={styles.page}>
      {product.name && <Title title={product.name}></Title>}
      <div className={styles.productDetailContainer}>
        <img
          src={`data:image/png;base64,${product.image}`}
          alt="Banner"
          className={styles.productDetailImage}
        />
        <div className={styles.description}>
          <div className={styles.descriptionText}>{product.description}</div>
          <div className={styles.descriptionBackground} />
        </div>
      </div>
      <div className={styles.similarProductsContainer}>
        {similarProducts.length > 0 && <h1>Outros produtos parecidos</h1>}
        <div className={styles.similarProductsImageContainer}>
          {similarProducts.length > 0
            ? similarProducts.map((similarProduct) => {
                return (
                  <SimilarProduct
                    image={similarProduct.image}
                    id={similarProduct.id}
                  />
                );
              })
            : undefined}
        </div>
      </div>
    </div>
  );
}
