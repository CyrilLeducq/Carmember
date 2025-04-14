import "../CookieConsent/cookieConsent.css"

const CookieConsent = ({title, text}) => {
  return (
    <div className="cookie-essential">
      <div className="cookie-essential__header">
        <h2 className="cookie-essential__title">{title}</h2>
        <div className="cookie-toggle">
          <div className="cookie-toggle__circle" />
        </div>
      </div>
      <p className="cookie-essential__text">
       {text}
      </p>
    </div>
  );
};

export default CookieConsent;