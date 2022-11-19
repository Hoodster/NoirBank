import React from 'react'
import PropTypes from 'prop-types'
import styles from './button.module.scss'
import clsx from 'clsx'

function Button({type, buttonStyle, style, icon, text, onClick}) {
	return <button onClick={onClick} style={style} className={clsx(styles['nb-button'], styles[type], styles[buttonStyle])}>
		{icon ? <span className={styles['nb-ico']}>{icon}</span> : null}
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