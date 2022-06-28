import React, { useRef, useContext } from "react";
import styles from "./Login.module.css";
import CustomButton from "../UI/Button/button";
import Card from "../UI/Card/Card";
import Input from "../UI/Input/Input";
import AuthContext from "../../store/auth-context";

const Login = (props) => {
  const ctx = useContext(AuthContext);
  const usernameInputRef = useRef();
  const passwordInputRef = useRef();
  const submitHandler = (event) => {
    event.preventDefault();
    ctx.onLogin(usernameInputRef.current.value, passwordInputRef.current.value);
  };

  return (
    <Card className={styles.login}>
      <form onSubmit={submitHandler}>
        <Input
          ref={usernameInputRef}
          id="username"
          label="User Name"
          type="input"
        ></Input>
        <Input
          ref={passwordInputRef}
          id="password"
          label="Password"
          type="password"
        ></Input>
        <div className={styles.actions}>
          <CustomButton type="submit" className={styles.btn}>
            Login
          </CustomButton>
        </div>
      </form>
    </Card>
  );
};

export default Login;
