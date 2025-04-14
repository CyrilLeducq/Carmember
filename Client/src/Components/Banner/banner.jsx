import "../Banner/banner.css"

function Banner({ image}) {
    return ( 
            <div className="banner-components">
                <div className="banner-img">
                    <img
                        src={image}
                        alt="Banner"
                        style={{ width: "50%", height: "auto" }}
                    />
                </div>
            </div>
     );
}

export default Banner;

