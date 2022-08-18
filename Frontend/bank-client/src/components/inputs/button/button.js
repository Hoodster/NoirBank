import React from 'react'
import PropTypes from 'prop-types'
import './button.scss'

function Button({type, style, icon, text, onClick}) {
	return <button onClick={onClick} className={`nb-button ${type} ${style}`}>
		{icon ? <span className="nb-ico">{icon}</span> : null}
		<span>{text}</span>
	</button>
}

Button.propTypes = {
	type: PropTypes.oneOf(['main', 'general']).isRequired,
	style: PropTypes.oneOf(['primary', 'accent']).isRequired,
	text: PropTypes.string.isRequired,
	icon: PropTypes.string,
	onClick: PropTypes.func
}

export default Button