import React from "react";
import styles from "./Navigation.module.css";

const Nagivation = (props) => {
  return (
    <nav className={styles.nav}>
      <ul>
        <li>
          <a href="/">Products</a>
        </li>
        <li>
          <button>Logout</button>
        </li>
      </ul>
    </nav>
  );
};

export default Nagivation;
