import React, { useState } from "react";
import right from "../../assets/right.png";
import left from "../../assets/left.png";
import "../Carroussel/carrousel.css"


function Carrousel({ slides }) {
	const [current, setCurrent] = useState(0);
	const length = slides.length;

	const nextSlide = () => {
		setCurrent(current === length - 1 ? 0 : current + 1);
	};

	const prevSlide = () => {
		setCurrent(current === 0 ? length - 1 : current - 1);
	};

	return (
		<section className="carrousel-container">
			{length > 1 && (
				<div className="carrousel-left" onClick={prevSlide}>
					<img src={left} alt="gauche" />
				</div>
			)}

			{length > 1 && (
				<div className="carrousel-right" onClick={nextSlide}>
					<img src={right} alt="droite" />
				</div>
			)}

			<div className="carrousel-content">
				{slides.map((Component, index) => (
					<div
						key={index}
						className={`slider ${current === index ? "active" : "noactive"}`}
					>
						{current === index && Component}
					</div>
				))}
			</div>
		</section>
	);
}

export default Carrousel;
