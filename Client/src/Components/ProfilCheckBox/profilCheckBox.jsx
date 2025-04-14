import "../ProfilCheckBox/profilCheckBox.css";

function ProfilCheckBox({ title, icon1, text1, icon2, text2, icon3, text3, onChange }) {
  const handleChange = (value) => {
    if (onChange) {
      onChange(value);
    }
  };

  return (
    <div className="profilCheckBox-contenant">
      <div className="contenant-title">{title}</div>

      <div className="contenant-choice">
        <div className="contenant-icon">{icon1}</div>
        <label className="contenant-text">
          <input
            type="radio"
            name={title}
            className="check-choice"
            onChange={() => handleChange(text1)}
          />
          <span>{text1}</span>
        </label>
      </div>

      <div className="contenant-choice">
        <div className="contenant-icon">{icon2}</div>
        <label className="contenant-text">
          <input
            type="radio"
            name={title}
            className="check-choice"
            onChange={() => handleChange(text2)}
          />
          <span>{text2}</span>
        </label>
      </div>

      <div className="contenant-choice">
        <div className="contenant-icon">{icon3}</div>
        <label className="contenant-text">
          <input
            type="radio"
            name={title}
            className="check-choice"
            onChange={() => handleChange(text3)}
          />
          <span>{text3}</span>
        </label>
      </div>
    </div>
  );
}

export default ProfilCheckBox;
