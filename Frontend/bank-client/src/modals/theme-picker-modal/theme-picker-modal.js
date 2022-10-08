import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'
import { setApplicationTheme } from '../../redux/reducers/settings-reducer'

function ThemePickerModal() {
	const dispatch = useDispatch()
	const [theme, setTheme] = useState(null)

	const primaryAction = {
		text: 'Change theme',
		action: () => dispatch(setApplicationTheme(theme))
	}

	const secondaryAction = {
		text: 'Cancel',
		action: () => dispatch(close())
	}
    
	return (
		<ModalBase primaryAction={primaryAction} secondaryAction={secondaryAction} title='Set application theme'>
			<select onChange={(e) => setTheme(e.target.value)}>
				<option value={'system'}>Default (system)</option>
				<option value={'dark'}>Dark</option>
				<option value={'light'}>Light</option>
			</select>
		</ModalBase>
	)
}

export default ThemePickerModal