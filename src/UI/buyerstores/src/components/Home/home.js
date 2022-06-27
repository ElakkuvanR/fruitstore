import React, { useContext } from "react";
import Button from "../UI/Button/button";
import AuthContext from '../../store/auth-context';

import Card from "../UI/Card/Card";
import styles from "./home.module.css";

const Home = (props) => {
  const ctx = useContext(AuthContext);
  return (
    <Card className={styles.home}>
      <h1>Welcome back!</h1>
      <Button onClick={ctx.onLogout}>Logout</Button>
    </Card>
  );
};

export default Home;