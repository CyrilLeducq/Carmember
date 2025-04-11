import "../ProfilCheckBox/profilCheckBox.css"
function profilCheckBox({title, icon1, text1, icon2, text2, icon3, text3}) {
    return ( 
        <div className="profilCheckBox-contenant">
            <div className="contenant-title">{title}</div>
            <div className="contenant-choice">
            <div className="contenant-icon">{icon1}</div>
            <label className="contenant-text">
            <input type="checkbox" name="check-choice" className="check-choice" /> 
            <span>{text1}</span>
            </label>
            </div>
            <div className="contenant-choice">
            <div className="contenant-icon">{icon2}</div>
            <label className="contenant-text">
            <input type="checkbox" name="check-choice" className="check-choice" />
            <span>{text2}</span>
            </label>
            </div>
            <div className="contenant-choice">
            <div className="contenant-icon">{icon3}</div>
            <label className="contenant-text">
            <input type="checkbox" name="check-choice" className="check-choice" /> 
            <span>{text3}</span>
            </label>
            </div>
        </div>
     );
}

export default profilCheckBox;