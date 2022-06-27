import React from "react";
import Nagivation from "./Navigation";
import styles from './Header.module.css';

const Header = (props) => {
  return (
    <header className={styles['main-header']}>
      <h1>A Simple Ordercloud Buyer App...</h1>
      <Nagivation></Nagivation>
    </header>
  );
};

export default Header;
