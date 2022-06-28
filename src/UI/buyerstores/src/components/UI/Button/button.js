import React from 'react';
import { Button } from 'react-bootstrap';

import classes from './button.module.css';

const CustomButton = (props) => {
  return (
    <Button variant="dark" size="lg"
      type={props.type || 'button'}
      className={`${classes.button} ${props.className}`}
      onClick={props.onClick}
      disabled={props.disabled}
    >
      {props.children}
    </Button>
  );
};

export default CustomButton;
