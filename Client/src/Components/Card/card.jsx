import './card.css';

function Card({ text, accentColor = "#2dd4bf", className = "" }) {
  return (
    <div className={`card-accent ${className}`}>
      <p>{text}</p>
      <div className="accent-square" style={{ backgroundColor: accentColor }}></div>
    </div>
  );
}

export default Card;
