import React from 'react'
import PropTypes from 'prop-types'
import './button.scss'

function Button({type, buttonStyle, style, icon, text, onClick}) {
	return <button onClick={onClick} style={style} className={`nb-button ${type} ${buttonStyle}`}>
		{icon ? <span className="nb-ico">{icon}</span> : null}
		<span>{text}</span>
	</button>
}

Button.propTypes = {
	type: PropTypes.oneOf(['main', 'general', 'modal']).isRequired,
	buttonStyle: PropTypes.oneOf(['primary', 'accent', 'accent-inverted']).isRequired,
	text: PropTypes.string.isRequired,
	icon: PropTypes.string,
	onClick: PropTypes.func,
	style: PropTypes.object
}

export default Button