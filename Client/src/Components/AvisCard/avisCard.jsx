import React from "react";
import "../AvisCard/avisCard.css";
import StarRating from '../StarRating/starRating';

function AvisCard({ passagerName, date, star, avis }) {
  return (
    <div className="avisCard-Component">
      <div className="avis-component-haut">
        <div className="avis-name">{passagerName}</div>
        <div className="avis-date">{date}</div>
      </div>
      <div className="avis-component-bas">
        <div className="avis-star">
          <StarRating totalRating={star} totalReviews={1} />
        </div>
        <div className="avis-avis">{avis}</div>
      </div>
    </div>
  );
}
export default AvisCard;
