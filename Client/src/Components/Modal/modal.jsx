import ReactDOM from "react-dom";
import React from "react";
import "../Modal/modal.css";

const Modal = ({ children, onClose }) => {
  const handleOverlayClick = (e) => {
    if (e.target.classList.contains("modal-overlay")) {
      onClose();
    }
  };

  return ReactDOM.createPortal(
    <div className="modal-overlay" onClick={handleOverlayClick}>
      <div className="modal-content">
        {children}
      </div>
    </div>,
    document.getElementById("modal-root")
  );
};

export default Modal;
