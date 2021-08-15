using System;

namespace config.c
{
    class ConfigurarEmpresa
    {
        public ConfigurarEmpresa(String empresa)
        {
            this.EMPRESA = empresa;
        }

        public String EMPRESA {get; set;}
    }
}