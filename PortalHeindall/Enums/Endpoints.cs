using System.ComponentModel;

namespace AppHeindall.Enums;

public enum Endpoints
{
    #region Grupos

    [Description("grupos")]
    Grupos,

    [Description("grupos/obterPorId")]
    GruposObterPorId,

    #endregion Grupos

    #region Usuários

    [Description("usuarios")]
    Usuarios,

    [Description("usuarios/obterPorId")]
    UsuariosObterPorId,

    #endregion Usuários

    #region Metas

    [Description("metas")]
    Metas,

    [Description("metas/obterPorId")]
    MetasObterPorId,

    #endregion Metas

    #region Integradores

    [Description("integradores")]
    Integradores,

    [Description("integradores/obterPorId")]
    IntegradoresObterPorId,

    #endregion Integradores

    #region IntegradoresDoUsuario

    [Description("integradoresDoUsuario")]
    IntegradoresDoUsuario,

    [Description("integradoresDoUsuario/obterPorId")]
    IntegradoresDoUsuarioObterPorId,

    #endregion IntegradoresDoUsuario
}